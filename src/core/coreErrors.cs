﻿// Copyright 2017 Anikin Dmitry, Mikhail Kudimov
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    class coreErrors : Exception
    {
        private int errorCode;
        private static string[] textMessage = new string[]
        {
            /*0*/ "No text.",
            /*1*/ "Error: the element doesn't exist among all threads.\nDeleting is not possible.",
            /*2*/ "Error: the element doesn't exist among all activeThreads.\nDeleting is not possible."
        };
        public enum errorCodes
        {
            NO_CODE,
            ELEMENT_DOES_NOT_EXIST_IN_THREADS,
            ELEMENT_DOES_NOT_EXIST_IN_ACTIVE_THREADS
        }

        public coreErrors(int anErrorCode)
        {
            errorCode = anErrorCode;
        }
        public override string Message
        {
            get
            {
                if (errorCode < 1 || errorCode > textMessage.Length - 1)
                    return textMessage[0];

                return textMessage[errorCode];
            }
        }

        public int ErrorCode { get { return errorCode; } }
        public void print()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Message);
            Console.ResetColor();
        }
    }
}
