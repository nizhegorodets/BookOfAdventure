// Copyright 2017 Anikin Dmitry, Mikhail Kudimov
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using core.Other_classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace core
{
    public class gameContext
    {
        // information about player
        private ILocation currLocation;
        private string playerName;

        // information about objects of game
        private List<ILocation> locations;
        private List<NPC> NPCs;
        private List<thread> threads;
        private List<uint?> activeThreads;


        // methods
        public void startGame()
        {
            for(int i = 0; i < activeThreads.Count; i++)
            {
                List<bool> endFlags = new List<bool>();
                // TODO: add check activeThreads[i] == null?
                thread currentTh = threads[Convert.ToInt32(activeThreads[i])];
                endFlags = currentTh.runState();
                bool endTh = endFlags[0];
                bool endGame = endFlags[1];

                if (endTh)
                {
                    //deleteActiveThreads(th);
                }

                if (endGame)
                {
                    //deleteActiveThreads(th);
                    break;
                }
            }
            Console.WriteLine("---\nКонец игры");
        }
        public void init()
        {
            threads = new List<thread>();
            activeThreads = new List<uint?>();
            NPCs = new List<NPC>();
        }

        public gameContext()
        {
            this.init();
        }
        public void deleteActiveThread(uint? input)
        {
            // delete only activeThreads
            for(uint? i = 0; i < activeThreads.Count; i++)
            {
                if (i == input)
                {
                    // TODO: may be change type of activeThreads to "math set"?
                    activeThreads.Remove(input);
                }
            }
            throw new coreErrors((int)coreErrors.errorCodes.ELEMENT_DOES_NOT_EXIST_IN_ACTIVE_THREADS);
        }
        public void deleteThreads(ref thread input)
        {
            // delete from activeThreads, threads and destroy input object
            deleteActiveThread(input.getThID());

            foreach (thread th in threads)
            {
                if (th == input)
                {
                    threads.Remove(input);
                    input = null;
                }
            }
            throw new coreErrors((int)coreErrors.errorCodes.ELEMENT_DOES_NOT_EXIST_IN_THREADS);
        }
        public void addThreads(thread input)
        {
            threads.Add(input);
        }
        public void addActiveThreads(thread input)
        {
            activeThreads.Add(input.getThID());
        }
        public void addLocation(ILocation input)
        {
            locations.Add(input);
        }
        public void addNPC(NPC input)
        {
            NPCs.Add(input);
        }
        public void setCurrLocation(ILocation input)
        {
            currLocation = input;
        }
        public void setPlayerName(string input)
        {
            playerName = input;
        }


        public ILocation CurrLocation
        {
            get { return currLocation; }
            set { currLocation = value; }
        }
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public List<ILocation> Locations
        {
            get { return locations; }
            set { locations = value; }
        }
        public List<NPC> nPCs
        {
            get { return NPCs; }
            set { NPCs = value; }
        }

        public List<thread> Threads
        {
            get { return threads; }
            set { threads = value; }
        }
        public List<uint?> ActiveThreads
        {
            get { return activeThreads; }
            set { activeThreads = value; }
        }

        public void Save(string file)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            File.WriteAllText(file, json, Encoding.UTF8);
        }

        public NPC getNPC(int index)
        {
            foreach(NPC npc in nPCs)
            {
                if(npc.MId == index)
                {
                    return npc;
                }
            }
            return null;
        }

        public thread getThread(int index)
        {
            foreach (thread th in Threads)
            {
                if (th.MID == index)
                {
                    return th;
                }
            }
            return null;
        }


        public void Load(string file)
        {
            gameContext obj = JsonConvert.DeserializeObject<gameContext>(File.ReadAllText(file), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            this.currLocation = obj.currLocation;
            this.playerName = obj.playerName;
            this.locations = obj.locations;
            this.NPCs = obj.NPCs;
            if(this.NPCs == null)
            {
                this.NPCs = new List<NPC>();
            }
            this.threads = obj.threads;
            this.activeThreads = obj.activeThreads;
        }
        public uint getIDForNewState()
        {
            int maxID = -1;

            foreach (thread th in this.threads)
                foreach (KeyValuePair<uint?, IState> st in th.MIDToIState)
                    if (st.Value.getID() > maxID)
                         maxID = (int)st.Value.getID();
            
            return (uint)maxID + 1;
        }

        public void exportToGraph()
        {
            foreach (thread th in this.threads)
            {
                StreamWriter sw = new StreamWriter("graph\\th" + th.MID.ToString() + ".txt");
                sw.WriteLine("digraph th" + th.MID.ToString() + "{");
                foreach (KeyValuePair<uint?, IState> st in th.MIDToIState)
                {
                    uint?[] nextStates = ((AState)st.Value).getNextStates();
                    foreach (uint? ns in nextStates)
                        sw.WriteLine("\"" + ((AState)st.Value).getGeneralDescription() + "\"" 
                            + "->" + "\"" + ((AState)th.MIDToIState[ns]).getGeneralDescription() +"\"" );
                }
                sw.WriteLine("}");
                sw.Close();
            }
        }
    }
}
