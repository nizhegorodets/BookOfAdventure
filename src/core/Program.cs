using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace core
{

    class Program
    {
        static void Main(string[] args)
        {
            // create gameContext
            gameContext gContext = new gameContext();
            gContext.init();
            thread thread1 = new thread();
            thread1.setID(0);

            // create state4 (в комнату к шумной компании)
            Phrase[] phrases = {
               new Phrase(0, "Вам потребовалось около семи секунд, чтобы раздеться и пройти."),
               new Phrase(0, "Окунувшись в дружескую атмосферу, ты расслабляешься и чувствуешь себя частливым."),
               new Phrase(0, "Вдруг ты чувствуешь странный запах. Он окутал тебя на мгновение."),
               new Phrase(0, "\"Что это за странный запах?\", - спрашиваешь ты. "),
               new Phrase(0, "\"Походу газ\", - протянул Валера. "),
               new Phrase(0, "На секунду все замерли, шевеля ноздрями. "),
               new Phrase(0, "О да. Это был газ. Газовая служба приехала и вовремя ликвидировала утечку. "),
               new Phrase(0, "Ты жив и теперь твоя кличка <<Парфюмер>>. Хэппи энд."),
            };
            IState state5 = new stateDialogue();
            uint?[] nextStates = new uint?[0] { };
            state5 = new stateDialogue(4, "state5 - dialogue", nextStates, phrases, true, true);

            // create state4 (ожидание 5 секунд)
            IState state4 = new stateWait();
            nextStates = new uint?[1] { state5.getID() };
            string title = "Ты скидываешь ботинки и верхнюю одежду...";
            state4 = new stateWait(3, "state4 - wait", nextStates, 7, title);

            // create state3 (за хозяином)
            phrases = new Phrase[] {
               new Phrase(0, "Отлично! Не разувайся, давай скорее посмотрим на него!"),
               new Phrase(0, "Ты протискиваешься в узкую кухоньку, перешагивая через кота."),
               new Phrase(0, "Большую часть стены рядом с окном занимает здоровенный гудящий холодильник."),
               new Phrase(0, "Блестит новенькая полированная поверхность прибора, блестит довольный хозяин, замечая твое удивление от этой диковинной вещицы."),
               new Phrase(0, "Вдруг ты чувствуешь странный запах. Он окутал тебя на мгновение."),
               new Phrase(0, "\"Здорово, да?\", - говорит хозяин, - \"Мы его в кредит взя..\""),
               new Phrase(0, "С этими словами хозяин открывает дверцу."),
               new Phrase(0, "Раздается громкий взрыв, но ты его уже не слышишь. "),
               new Phrase(0, "Ты даже не успеваешь подумать, что тот странный запах - это запах газа."),
               new Phrase(0, "При открытии холодильника внутри загорается лампочка, это она дала искру."),
               new Phrase(0, "Ты мертв.")
            };
            IState state3 = new stateDialogue();
            nextStates = new uint?[0] { };
            state3 = new stateDialogue(2, "state4 - dialogue", nextStates, phrases, true, true);

            // create state2 (куда ты направляешься?)
            Choice[] choices = new Choice[]
            {
                new Choice(0, "За гостеприимным хозяином смотреть холодильник"),
                new Choice(1, "В комнату к шумной компанией")
            };
            IState state2 = new stateChoice();
            nextStates = new uint?[2] { state3.getID(), state4.getID() };
            title = "Куда ты решил направиться первым делом?";
            state2 = new stateChoice(1, "state2 - choice", nextStates, choices, title);

            // create state1 (вход в дом)
            phrases = new Phrase[] {
                           new Phrase(0, "Хорошо, что ты пришел! Мы так долго тебя ждали!"),
                           new Phrase(0, "Проходи, располагайся. Здесь и Игнат, и Валера, и даже тот самый парень с гитарой."),
                           new Phrase(0, "Я их тебе сейчас представлю... Скидывай ты уже наконец свое пальто!"),
                           new Phrase(0, "Кстати, мы с женкой купили новый первоклассный холодильник марки <<Морозко>>")
                       };
            nextStates = new uint?[1] { state2.getID() };
            IState state1 = new stateDialogue(0, "state1 - dialogue", nextStates, phrases, false, false);

            // add state to thread
            thread1.addState(state1);
            thread1.addState(state2);
            thread1.addState(state3);
            thread1.addState(state4);
            thread1.addState(state5);
            // start game
            thread1.setCurrentState(0);
            gContext.addThreads(thread1);
            gContext.addActiveThreads(thread1);

            // Сохраняем созданный квест в файл

            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\people.json";
            gContext.Save(path);

            // Можно загрузить его в новую переменную и запустить

            
            gameContext gContext1 = new gameContext();
            gContext1.Load(path);
            gContext1.startGame();
            

            //gContext.startGame();
        }
    }
}
