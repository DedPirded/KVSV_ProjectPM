using System;

namespace ConsoleVersionOfKVSV
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateNow = new DateTime();
            dateNow = DateTime.Today;
            DateTime daysNextKvartal = new DateTime();
            int[] dates = YearsMonthDays(dateNow);
            //Console.WriteLine("Hell to World!");
            int kvartal = Kvartal(dates);
            /*for (int i = 0; i < dates.Length; i++)
            {
                Console.WriteLine(dates[i]);
            }*/
            int dayOfNextKvartal = DaysToKvartal(kvartal, dates, dateNow, ref daysNextKvartal);
            //Console.WriteLine(dayOfNextKvartal);
            //Console.WriteLine(daysNextKvartal.ToShortDateString());
            Console.WriteLine("Выберите: ФЛП(1), ООО(2 - пока не реализована).");
            char sym = Convert.ToChar(Console.ReadLine());
            switch (sym)
            {
                case '1': //ФЛП
                    Console.WriteLine("У вас есть наёмные рабочие? Да(1), Нет(2).");
                    sym = Convert.ToChar(Console.ReadLine());                  
                    switch (sym)
                    {
                        case '1': //Есть наёмные рабочие
                            Console.WriteLine("Выберите систему налогооблажения? Единый налог(1), Общая система(2).");
                            sym = Convert.ToChar(Console.ReadLine());
                            switch (sym)
                            {
                                case '1': //ФЛП c наёмными рабочими на Едином налоге
                                    Console.WriteLine("ФЛП c наёмными рабочими на Едином налоге");
                                    break;
                                case '2': //ФЛП с наёмными рабочими на общей системе НО
                                    Console.WriteLine("ФЛП с наёмными рабочими на общей системе НО");
                                    break;
                            }
                            break;
                        case '2': //Нет наёмных рабочих
                            Console.WriteLine("Выберите систему налогооблажения? Единый налог(1), Общая система(2).");
                            sym = Convert.ToChar(Console.ReadLine());
                            switch (sym)
                            {
                                case '1': //ФЛП без наёмных рабочих на Едином налоге
                                    Console.WriteLine("ФЛП без наёмных рабочих на Едином налоге");
                                    break;
                                case '2': //ФЛП без наёмных рабочих на общей системе НО
                                    Console.WriteLine("Вы ФЛП без наёмных рабочих на общей системе налогооблажения");
                                    FLPWithOutRonNO(dayOfNextKvartal, daysNextKvartal, dates);
                                    //DateTime dateESV = new DateTime(2020, 1, 1);                                 
                                    break;
                            }
                            break;
                    }
                    break;
                case '2': //ООО
                    Console.WriteLine("Пока не реализована");
                    break;
            }
        }
        static int Kvartal(int[] dates)
        {          
            int numOfKvartal;
            int month = dates[1];
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    numOfKvartal = 1;
                    break;
                case 4:
                case 5:
                case 6:
                    numOfKvartal = 2;
                    break;
                case 7:
                case 8:
                case 9:
                    numOfKvartal = 3;
                    break;
                default:
                    numOfKvartal = 4;
                    break;
                
            }
            return numOfKvartal;
        }
        static int[] YearsMonthDays(DateTime date)
        {
            int[] f = new int[3];
            string sDays = date.ToString("dd");
            f[0] = Convert.ToInt32(sDays);
            string sMonth = date.ToString("MM");
            f[1] = Convert.ToInt32(sMonth);          
            string sYears = date.ToString("yyyy");
            f[2] = Convert.ToInt32(sYears);
            return f;
        }
        static int DaysToKvartal(int kvartal, int[] dates, DateTime dateNow, ref DateTime daysNextKvartal)
        {
            int nextKvartal = kvartal + 1;
            if (nextKvartal == 5)
            {
                nextKvartal = 1;
            }
            switch (nextKvartal)
            {
                case 1:
                    daysNextKvartal = new DateTime(dates[2] + 1, 1, 1);
                    break;
                case 2:
                    daysNextKvartal = new DateTime(dates[2], 4, 1);
                    break;
                case 3:
                    daysNextKvartal = new DateTime(dates[2], 7, 1);
                    break;
                case 4:
                    daysNextKvartal = new DateTime(dates[2], 10, 1);
                    break;
            }
            TimeSpan f = daysNextKvartal.Subtract(dateNow);
            string sF = f.ToString();
            char[] cArr = sF.ToCharArray();
            int[] arr = new int[2];
            arr[0] = (cArr[0] - '0') * 10;
            arr[1] = cArr[1] - '0';
            int daysToKvartal = arr[0] + arr[1];
            return daysToKvartal;
        }
        static DateTime DateOfFirstKvartal(int[] dates)
        {          
            DateTime dateFirstKvartal = new DateTime(dates[2] + 1, 1, 1);
            return dateFirstKvartal;

        }
        static void FLPWithOutRonNO(int dayOfNextKvartal, DateTime daysNextKvartal, int[] dates)
        {
            Console.WriteLine("Вы платите один налог: 'Уплата ЕСВ'. Так же вы сдаёте один отчет: 'Отчёт по ЕСВ'");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕСВ', нажмите цифру: 1");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчёт по ЕСВ', нажмите цифру: 2");
            Console.WriteLine("Если вы хотите узнать сроки оплаты и сдачи отчётов, нажмите цифру: 3");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine(" Единый социальный взнос — обязательный взнос в общегосударственную систему социального страхования\n с целью защиты в случаях, предусмотренных законодательством, прав застрахованных\n лиц на получение страховых выплат. Не входит в систему налогообложения — порядок его начисления,\n расчета и уплаты регулируется Государственной фискальной службой Украины. Единый социальный взнос перечисляется\n на счета налоговой инспекции, в которой зарегистрирован предприниматель.\n ");
                    Console.WriteLine(" Уплачивается на протяжении 19 дней, следующих за кварталом, за который производится уплата. \n Размер социального взноса определяется предпринимателем самостоятельно,\n но не может быть меньше минимальной ставки, установленной для выбранной категории плательщика ЕСВ\n (для предпринимателей на упрощенной системе налогообложения 1-3 групп это 22% от текущей минимальной зарплаты).\n");
                    Console.WriteLine(" За неуплату (неперечисление) или несвоевременную уплату (несвоевременное перечисление) единого\n взноса предусмотрен штраф в размере 20% своевременно неуплаченных сумм.");
                    break;
                case 2:
                    Console.WriteLine($" Отчет о суммах начисленного дохода застрахованных лиц и суммах начисленного единого взноса за {dates[2] - 1} год.\n Подается в ГФС не позже 9 февраля года, следующего за отчетным.");
                    break;
                case 3:
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕСВ' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(20).ToShortDateString()}.");
                    Console.WriteLine("Сумма оплаты: 2 754,18 грн");
                    DateTime dateOfFirstKvartal = DateOfFirstKvartal(dates);
                    Console.WriteLine($"Дата следующей сдачи 'Отчета по ЕСВ': с {dateOfFirstKvartal.ToShortDateString()} до {dateOfFirstKvartal.AddDays(40).ToShortDateString()}.");
                    break;
                default:
                    break;
            }
        }
    }
}
