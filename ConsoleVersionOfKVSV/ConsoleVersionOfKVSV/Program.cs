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
            bool repeat = true;
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
                                    Console.WriteLine("Выберите группу: 1 группа(1), 2 группа(2), 3 группа(3)");
                                    sym = Convert.ToChar(Console.ReadLine());
                                    switch (sym)
                                    {                                  
                                        case '1':
                                            while (repeat)
                                            {
                                                Console.WriteLine("Вы ФЛП с наёмными рабочими на Едином налоге(1 группа)");
                                                FLPWithOutRonEN2(dayOfNextKvartal, daysNextKvartal, dates, 1, dateNow, ref repeat);
                                            }                                          
                                            break;
                                        case '2':
                                            while (repeat)
                                            {
                                                Console.WriteLine("Вы ФЛП с наёмными рабочими на Едином налоге(2 группа)");
                                                FLPWithRonEN2(dayOfNextKvartal, daysNextKvartal, dates, dateNow, ref repeat);
                                            }                                            
                                            break;
                                        case '3':
                                            while (repeat)
                                            {
                                                Console.WriteLine("Вы ФЛП с наёмными рабочими на Едином налоге(3 группа)");
                                                FLPWithRonEN3(dayOfNextKvartal, daysNextKvartal, dates, dateNow, ref repeat);
                                            }                                           
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case '2': //ФЛП с наёмными рабочими на общей системе НО                                   
                                    while (repeat)
                                    {
                                        Console.WriteLine("Вы ФЛП с наёмными рабочими на общей системе НО");
                                        FLPWithRonNO(dayOfNextKvartal, daysNextKvartal, dates, kvartal, dateNow, ref repeat);
                                    }                                    
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
                                    Console.WriteLine("Выберите группу: 1 группа(1), 2 группа(2), 3 группа(3)");
                                    sym = Convert.ToChar(Console.ReadLine());
                                    switch (sym)
                                    {
                                        case '1':
                                            while (repeat)
                                            {
                                                Console.WriteLine("Вы ФЛП без наёмных рабочих на Едином налоге(1 группа)");
                                                FLPWithOutRonEN2(dayOfNextKvartal, daysNextKvartal, dates, 1, dateNow, ref repeat);
                                            }                                           
                                            break;
                                        case '2':
                                            while (repeat)
                                            {
                                                Console.WriteLine("Вы ФЛП без наёмных рабочих на Едином налоге(2 группа)");
                                                FLPWithOutRonEN2(dayOfNextKvartal, daysNextKvartal, dates, 2, dateNow, ref repeat);
                                            }                                          
                                            break;
                                        case '3':
                                            while (repeat)
                                            {
                                                Console.WriteLine("Вы ФЛП без наёмных рабочих на Едином налоге(3 группа)");
                                                FLPWithOutRonEN3(dayOfNextKvartal, daysNextKvartal, dates, ref repeat);
                                            }                                           
                                            break;
                                        default:
                                            break;
                                    }
                                    break;
                                case '2': //ФЛП без наёмных рабочих на общей системе НО                                   
                                    while (repeat)
                                    {
                                        Console.WriteLine("Вы ФЛП без наёмных рабочих на общей системе налогооблажения");
                                        FLPWithOutRonNO(dayOfNextKvartal, daysNextKvartal, dates, ref repeat);
                                    }                                    
                                    //DateTime dateESV = new DateTime(2020, 1, 1);                                 
                                    break;
                            }
                            break;
                    }
                    break;
                case '2': //ООО
                    Console.WriteLine("Пока не реализована");
                    break;
                default:
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
        static DateTime DateOfNearMonth(int[] dates)
        {
            DateTime dateOfNearMonth = new DateTime(dates[2], dates[1] + 1, 1);
            return dateOfNearMonth;
        }      
        static TimeSpan DaysToNearMonth(DateTime dateNow, DateTime dateOfNearMonth)   //Не работает
        {
            TimeSpan f = dateOfNearMonth.Subtract(dateNow);           
            return f;
        }
        static void FLPWithOutRonNO(int dayOfNextKvartal, DateTime daysNextKvartal, int[] dates, ref bool repeat)
        {
            Console.WriteLine("Вы платите один налог: 'Уплата ЕСВ'. Так же вы сдаёте один отчет: 'Отчёт по ЕСВ'");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕСВ', нажмите цифру: 1");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчёт по ЕСВ', нажмите цифру: 2");
            Console.WriteLine("Если вы хотите узнать сроки оплаты и сдачи отчётов, нажмите цифру: 3");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("Единый социальный взнос — обязательный взнос в общегосударственную систему социального страхования\nс целью защиты в случаях, предусмотренных законодательством, прав застрахованных\nлиц на получение страховых выплат. Не входит в систему налогообложения — порядок его начисления,\nрасчета и уплаты регулируется Государственной фискальной службой Украины. Единый социальный взнос перечисляется\nна счета налоговой инспекции, в которой зарегистрирован предприниматель.\n");
                    Console.WriteLine("Уплачивается на протяжении 19 дней, следующих за кварталом, за который производится уплата. \nРазмер социального взноса определяется предпринимателем самостоятельно,\nно не может быть меньше минимальной ставки, установленной для выбранной категории плательщика ЕСВ\n(для предпринимателей на упрощенной системе налогообложения 1-3 групп это 22% от текущей минимальной зарплаты).\n");
                    Console.WriteLine("За неуплату (неперечисление) или несвоевременную уплату (несвоевременное перечисление) единого\nвзноса предусмотрен штраф в размере 20% своевременно неуплаченных сумм.");
                    break;
                case 2:
                    Console.WriteLine($"Отчет о суммах начисленного дохода застрахованных лиц и суммах начисленного единого взноса за {dates[2] - 1} год.\nПодается в ГФС не позже 9 февраля года, следующего за отчетным.");
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
            Console.WriteLine("Желаете еще что-то узнать о ваших налогах или отчётах? Да(1), Нет(2)");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {
                repeat = true;
            }
            else
                repeat = false;
        }
        static void FLPWithOutRonEN3(int dayOfNextKvartal, DateTime daysNextKvartal, int[] dates, ref bool repeat)
        {
            Console.WriteLine("Вы платите два налога: 'Улата ЕСВ' и 'Уплата ЕН'.\nТак же вы сдаёте два документа: 'Отчет по ЕСВ' и 'Налоговая декларация'.");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕСВ', нажмите цифру: 1");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕН', нажмите цифру: 2");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчёт по ЕСВ', нажмите цифру: 3");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Налоговая декларация', нажмите цифру: 4");
            Console.WriteLine("Если вы хотите узнать сроки оплаты и сдачи отчётов, нажмите цифру: 5");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("Единый социальный взнос — обязательный взнос в общегосударственную систему социального страхования\nс целью защиты в случаях, предусмотренных законодательством, прав застрахованных\nлиц на получение страховых выплат. Не входит в систему налогообложения — порядок его начисления,\nрасчета и уплаты регулируется Государственной фискальной службой Украины. Единый социальный взнос перечисляется\nна счета налоговой инспекции, в которой зарегистрирован предприниматель.\n");
                    Console.WriteLine("Уплачивается на протяжении 19 дней, следующих за кварталом, за который производится уплата. \nРазмер социального взноса определяется предпринимателем самостоятельно,\nно не может быть меньше минимальной ставки, установленной для выбранной категории плательщика ЕСВ\n(для предпринимателей на упрощенной системе налогообложения 1-3 групп это 22% от текущей минимальной зарплаты).\n");
                    Console.WriteLine("За неуплату (неперечисление) или несвоевременную уплату (несвоевременное перечисление) единого\nвзноса предусмотрен штраф в размере 20% своевременно неуплаченных сумм.");
                    break;
                case 2:
                    Console.WriteLine("Единый налог — налог, оплачиваемый субъектами хозяйственной деятельности на упрощенной системе\nналогообложения, основной предпринимательский налог. Перечисляется в местный\nналоговый бюджет и оплачивается на счета налоговой инспекции, в которой зарегистрирован\nсубъект хозяйственной деятельности.");
                    Console.WriteLine("Уплачивается не позже 10 календарных дней, следующих за последним днем сдачи квартальной декларации\n(в течение 50 дней после окончания отчетного квартала). Размер ставки единого\nналога для третьей группы устанавливается в размере 3% от дохода за квартал для плательщиков НДС\nи 5% от дохода за квартал для неплательщиков");
                    Console.WriteLine("За неуплату единого налога предусмотрен штраф в размере 10% от неуплаченной суммы.");
                    break;
                case 3:
                    Console.WriteLine($"Отчет о суммах начисленного дохода застрахованных лиц и суммах начисленного единого взноса за {dates[2] - 1} год.\nПодается в ГФС не позже 9 февраля года, следующего за отчетным.");
                    break;
                case 4:
                    Console.WriteLine("Налоговая декларация отражает заработанную предпринимателем сумму за отчетный период (сумма считается накопительно\nс начала года), а также сумму уплаченных налогов. Задекларированная сумма является основанием и\nобязательством к уплате единого налога для предпринимателей 3 группы");
                    Console.WriteLine("Подаётся в ГФС не позже 40 календарных дней, следующих за последним календарным днем отчетного квартала");
                    break;
                case 5:
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕСВ' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(20).ToShortDateString()}.");
                    Console.WriteLine("Сумма оплаты: 2 754,18 грн");
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕН' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(50).ToShortDateString()}.");
                    Console.WriteLine("Сумма оплаты: 5% от дохода");
                    DateTime dateOfFirstKvartal = DateOfFirstKvartal(dates);
                    Console.WriteLine($"Дата следующей сдачи 'Отчета по ЕСВ': с {dateOfFirstKvartal.ToShortDateString()} до {dateOfFirstKvartal.AddDays(40).ToShortDateString()}.");
                    Console.WriteLine($"Вы должны сдать 'Налоговая декларация' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(40).ToShortDateString()}");
                    break;
                default:
                    break;
            }
            Console.WriteLine("Желаете еще что-то узнать о ваших налогах или отчётах? Да(1), Нет(2)");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {
                repeat = true;
            }
            else
                repeat = false;
        }
        static void FLPWithOutRonEN2(int dayOfNextKvartal, DateTime daysNextKvartal, int[] dates, int nomerGrupi, DateTime dateNow, ref bool repeat)
        {
            Console.WriteLine("Вы платите два налога: 'Улата ЕСВ' и 'Уплата ЕН'.\nТак же вы сдаёте два документа: 'Отчет по ЕСВ' и 'Налоговая декларация'.");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕСВ', нажмите цифру: 1");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕН', нажмите цифру: 2");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчёт по ЕСВ', нажмите цифру: 3");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Налоговая декларация', нажмите цифру: 4");
            Console.WriteLine("Если вы хотите узнать сроки оплаты и сдачи отчётов, нажмите цифру: 5");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("Единый социальный взнос — обязательный взнос в общегосударственную систему социального страхования\nс целью защиты в случаях, предусмотренных законодательством, прав застрахованных\nлиц на получение страховых выплат. Не входит в систему налогообложения — порядок его начисления,\nрасчета и уплаты регулируется Государственной фискальной службой Украины. Единый социальный взнос перечисляется\nна счета налоговой инспекции, в которой зарегистрирован предприниматель.\n");
                    Console.WriteLine("Уплачивается на протяжении 19 дней, следующих за кварталом, за который производится уплата. \nРазмер социального взноса определяется предпринимателем самостоятельно,\nно не может быть меньше минимальной ставки, установленной для выбранной категории плательщика ЕСВ\n(для предпринимателей на упрощенной системе налогообложения 1-3 групп это 22% от текущей минимальной зарплаты).\n");
                    Console.WriteLine("За неуплату (неперечисление) или несвоевременную уплату (несвоевременное перечисление) единого\nвзноса предусмотрен штраф в размере 20% своевременно неуплаченных сумм.");
                    break;
                case 2:
                    Console.WriteLine("Единый налог — налог, оплачиваемый субъектами хозяйственной деятельности на упрощенной системе\nналогообложения, основной предпринимательский налог. Перечисляется в местный\nналоговый бюджет и оплачивается на счета налоговой инспекции, в которой зарегистрирован\nсубъект хозяйственной деятельности.");
                    if (nomerGrupi == 1)
                    {
                        Console.WriteLine($"Уплачивается авансом до 20 числа текущего месяца. Сумма составляет процент в размере налоговой\nставки от прожиточного минимума, установленного на январь {dates[2]}");
                    }
                    else
                    {
                        Console.WriteLine($"Уплачивается авансом до 20 числа текущего месяца. Сумма составляет процент в размере налоговой\nставки от минимальной заработной платы, установленной на январь {dates[2]}");
                    }                
                    Console.WriteLine("За неуплату единого налога предусмотрен штраф в размере 50% от налоговой ставки (неуплаченной суммы\nединого налога).");
                    break;
                case 3:
                    Console.WriteLine($"Отчет о суммах начисленного дохода застрахованных лиц и суммах начисленного единого взноса за {dates[2] - 1} год.\nПодается в ГФС не позже 9 февраля года, следующего за отчетным.");
                    break;
                case 4:
                    Console.WriteLine($"Налоговая декларация отражает заработанную предпринимателем сумму, а также сумму уплаченных налогов за {dates[2] - 1}");
                    Console.WriteLine("Подаётся в ГФС не позже 60 календарных дней, следующих за последним календарным днем отчетного года");
                    break;
                case 5:
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕСВ' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(20).ToShortDateString()}.");
                    Console.WriteLine("Сумма оплаты: 2 754,18 грн");
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕН' через {DaysToNearMonth(dateNow, DateOfNearMonth(dates)).ToString("dd")} дней, а именно: с {DateOfNearMonth(dates).ToShortDateString()} до {DateOfNearMonth(dates).AddDays(20).ToShortDateString()}.");
                    if(nomerGrupi == 1)
                    {
                        Console.WriteLine("Сумма оплаты: 210,20 грн");
                    }
                    else
                    {
                        Console.WriteLine("Сумма оплаты: 944,60 грн");
                    }
                    DateTime dateOfFirstKvartal = DateOfFirstKvartal(dates);
                    Console.WriteLine($"Дата следующей сдачи 'Отчета по ЕСВ': с {dateOfFirstKvartal.ToShortDateString()} до {dateOfFirstKvartal.AddDays(40).ToShortDateString()}.");
                    Console.WriteLine($"Дата следующей сдачи 'Налоговая декларация': с {dateOfFirstKvartal.ToShortDateString()} до {dateOfFirstKvartal.AddDays(60).ToShortDateString()}.");
                    break;
                default:
                    break;                   
            }
            Console.WriteLine("Желаете еще что-то узнать о ваших налогах или отчётах? Да(1), Нет(2)");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {
                repeat = true;
            }
            else
                repeat = false;
        }
        static void FLPWithRonNO(int dayOfNextKvartal, DateTime daysNextKvartal, int[] dates, int kvartal, DateTime dateNow, ref bool repeat)
        {
            Console.WriteLine("Вы платите один налог: 'Уплата ЕСВ'.\nТак же вы сдаёте три отчета: 'Отчёт по ЕСВ', 'Налоговый расчет' и \n'Отчет о суммах начисленной заработной платы и суммах начисленного ЕСВ'");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕСВ', нажмите цифру: 1");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчёт по ЕСВ', нажмите цифру: 2");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Налоговый расчет', нажмите цифру: 3");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчет о суммах начисленной заработной платы и суммах начисленного ЕСВ', нажмите цифру: 4");
            Console.WriteLine("Если вы хотите узнать сроки оплаты и сдачи отчётов, нажмите цифру: 5");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("Единый социальный взнос — обязательный взнос в общегосударственную систему социального страхования\nс целью защиты в случаях, предусмотренных законодательством, прав застрахованных\nлиц на получение страховых выплат. Не входит в систему налогообложения — порядок его начисления,\nрасчета и уплаты регулируется Государственной фискальной службой Украины. Единый социальный взнос перечисляется\nна счета налоговой инспекции, в которой зарегистрирован предприниматель.\n");
                    Console.WriteLine("Уплачивается на протяжении 19 дней, следующих за кварталом, за который производится уплата. \nРазмер социального взноса определяется предпринимателем самостоятельно,\nно не может быть меньше минимальной ставки, установленной для выбранной категории плательщика ЕСВ\n(для предпринимателей на упрощенной системе налогообложения 1-3 групп это 22% от текущей минимальной зарплаты).\n");
                    Console.WriteLine("За неуплату (неперечисление) или несвоевременную уплату (несвоевременное перечисление) единого\nвзноса предусмотрен штраф в размере 20% своевременно неуплаченных сумм.");
                    break;
                case 2:
                    Console.WriteLine($"Отчет о суммах начисленного дохода застрахованных лиц и суммах начисленного единого взноса за {dates[2] - 1} год.\nПодается в ГФС не позже 9 февраля года, следующего за отчетным.");
                    break;
                case 3:
                    Console.WriteLine("Налоговый расчет - документ, свидетельствующий о суммах дохода, начисленного (выплаченного) в пользу\nналогоплательщиков — физических лиц, суммы удержанного и/или уплаченного налога.");
                    Console.WriteLine("Подаётся в течении 40 календарных дней, следующих за последним календарным днем отчетного квартала.");
                    break;
                case 4:
                    Console.WriteLine("Это отчет о суммах начисленной заработной платы (дохода, денежного обеспечения, помощи, компенсации)\nзастрахованных лиц и суммах начисленного единого взноса на общеобязательное\nгосударственное социальное страхование в органы доходов и сборов.");
                    Console.WriteLine("Подаётся в течении 20 календарных дней, следующих за последним днем отчетного периода.");
                    break;
                case 5:
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕСВ' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(20).ToShortDateString()}.");
                    Console.WriteLine("Сумма оплаты: 2 754,18 грн");
                    Console.WriteLine($"Дата следующей сдачи 'Отчета по ЕСВ': с {DateOfFirstKvartal(dates).ToShortDateString()} до {DateOfFirstKvartal(dates).AddDays(40).ToShortDateString()}.");
                    Console.WriteLine($"Вы должны сдать 'Налоговый расчет' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(40).ToShortDateString()}");
                    Console.WriteLine($"Вы должны сдать 'Отчет о суммах начисленной заработной платы и суммах начисленного ЕСВ' через {DaysToNearMonth(dateNow, DateOfNearMonth(dates)).ToString("dd")} дней,\nа именно с {DateOfNearMonth(dates).ToShortDateString()} до {DateOfNearMonth(dates).AddDays(20).ToShortDateString()}");
                    break;
                default:
                    break;
            }
            Console.WriteLine("Желаете еще что-то узнать о ваших налогах или отчётах? Да(1), Нет(2)");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {
                repeat = true;
            }
            else
                repeat = false;
        }
        static void FLPWithRonEN2(int dayOfNextKvartal, DateTime daysNextKvartal, int[] dates, DateTime dateNow, ref bool repeat)
        {
            Console.WriteLine("Вы платите два налога: 'Уплата ЕСВ' и 'Уплата ЕН'.\nТак же вы сдаёте четыре отчета: 'Отчёт по ЕСВ', 'Налоговый расчет', \n'Отчет о суммах начисленной заработной платы и суммах начисленного ЕСВ' и \n'Налоговая декларация'");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕСВ', нажмите цифру: 1");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕН', нажмите цифру: 2");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчёт по ЕСВ', нажмите цифру: 3");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Налоговый расчет', нажмите цифру: 4");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчет о суммах начисленной заработной платы и суммах начисленного ЕСВ', нажмите цифру: 5");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Налоговая декларация', нажмите цифру: 6");
            Console.WriteLine("Если вы хотите узнать сроки оплаты и сдачи отчётов, нажмите цифру: 7");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("Единый социальный взнос — обязательный взнос в общегосударственную систему социального страхования\nс целью защиты в случаях, предусмотренных законодательством, прав застрахованных\nлиц на получение страховых выплат. Не входит в систему налогообложения — порядок его начисления,\nрасчета и уплаты регулируется Государственной фискальной службой Украины. Единый социальный взнос перечисляется\nна счета налоговой инспекции, в которой зарегистрирован предприниматель.\n");
                    Console.WriteLine("Уплачивается на протяжении 19 дней, следующих за кварталом, за который производится уплата. \nРазмер социального взноса определяется предпринимателем самостоятельно,\nно не может быть меньше минимальной ставки, установленной для выбранной категории плательщика ЕСВ\n(для предпринимателей на упрощенной системе налогообложения 1-3 групп это 22% от текущей минимальной зарплаты).\n");
                    Console.WriteLine("За неуплату (неперечисление) или несвоевременную уплату (несвоевременное перечисление) единого\nвзноса предусмотрен штраф в размере 20% своевременно неуплаченных сумм.");
                    break;
                case 2:
                    Console.WriteLine("Единый налог — налог, оплачиваемый субъектами хозяйственной деятельности на упрощенной системе\nналогообложения, основной предпринимательский налог. Перечисляется в местный\nналоговый бюджет и оплачивается на счета налоговой инспекции, в которой зарегистрирован\nсубъект хозяйственной деятельности.");
                    Console.WriteLine($"Уплачивается авансом до 20 числа текущего месяца. Сумма составляет процент в размере налоговой\nставки от минимальной заработной платы, установленной на январь {dates[2]}");
                    Console.WriteLine("За неуплату единого налога предусмотрен штраф в размере 50% от налоговой ставки (неуплаченной суммы\nединого налога).");
                    break;
                case 3:
                    Console.WriteLine($"Отчет о суммах начисленного дохода застрахованных лиц и суммах начисленного единого взноса за {dates[2] - 1} год.\nПодается в ГФС не позже 9 февраля года, следующего за отчетным.");
                    break;
                case 4:
                    Console.WriteLine("Налоговый расчет - документ, свидетельствующий о суммах дохода, начисленного (выплаченного) в пользу\nналогоплательщиков — физических лиц, суммы удержанного и/или уплаченного налога.");
                    Console.WriteLine("Подаётся в течении 40 календарных дней, следующих за последним календарным днем отчетного квартала.");
                    break;
                case 5:
                    Console.WriteLine("Это отчет о суммах начисленной заработной платы (дохода, денежного обеспечения, помощи, компенсации)\nзастрахованных лиц и суммах начисленного единого взноса на общеобязательное\nгосударственное социальное страхование в органы доходов и сборов.");
                    Console.WriteLine("Подаётся в течении 20 календарных дней, следующих за последним днем отчетного периода.");
                    break;
                case 6:
                    Console.WriteLine($"Налоговая декларация отражает заработанную предпринимателем сумму, а также сумму уплаченных налогов за {dates[2] - 1}");
                    Console.WriteLine("Подаётся в ГФС не позже 60 календарных дней, следующих за последним календарным днем отчетного года");
                    break;
                case 7:
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕСВ' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(20).ToShortDateString()}.");
                    Console.WriteLine("Сумма оплаты: 2 754,18 грн");
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕН' через {DaysToNearMonth(dateNow, DateOfNearMonth(dates)).ToString("dd")} дней, а именно: с {DateOfNearMonth(dates).ToShortDateString()} до {DateOfNearMonth(dates).AddDays(20).ToShortDateString()}.");
                    Console.WriteLine("Сумма оплаты: 944,60 грн");
                    Console.WriteLine($"Дата следующей сдачи 'Отчета по ЕСВ': с {DateOfFirstKvartal(dates).ToShortDateString()} до {DateOfFirstKvartal(dates).AddDays(40).ToShortDateString()}.");
                    Console.WriteLine($"Вы должны сдать 'Налоговый расчет' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(40).ToShortDateString()}");
                    Console.WriteLine($"Вы должны сдать 'Отчет о суммах начисленной заработной платы и суммах начисленного ЕСВ' через {DaysToNearMonth(dateNow, DateOfNearMonth(dates)).ToString("dd")} дней,\nа именно с {DateOfNearMonth(dates).ToShortDateString()} до {DateOfNearMonth(dates).AddDays(20).ToShortDateString()}");
                    Console.WriteLine($"Дата следующей сдачи 'Налоговая декларация': с {DateOfFirstKvartal(dates).ToShortDateString()} до {DateOfFirstKvartal(dates).AddDays(60).ToShortDateString()}.");
                    break;
                default:
                    break;
            }
            Console.WriteLine("Желаете еще что-то узнать о ваших налогах или отчётах? Да(1), Нет(2)");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {
                repeat = true;
            }
            else
                repeat = false;

        }
        static void FLPWithRonEN3(int dayOfNextKvartal, DateTime daysNextKvartal, int[] dates, DateTime dateNow, ref bool repeat)
        {
            Console.WriteLine("Вы платите два налога: 'Уплата ЕСВ' и 'Уплата ЕН'.\nТак же вы сдаёте четыре отчета: 'Отчёт по ЕСВ', 'Налоговый расчет', \n'Отчет о суммах начисленной заработной платы и суммах начисленного ЕСВ' и \n'Налоговая декларация'");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕСВ', нажмите цифру: 1");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Уплата ЕН', нажмите цифру: 2");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчёт по ЕСВ', нажмите цифру: 3");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Налоговый расчет', нажмите цифру: 4");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Отчет о суммах начисленной заработной платы и суммах начисленного ЕСВ', нажмите цифру: 5");
            Console.WriteLine("Если вы хотите узнать больше информации о 'Налоговая декларация', нажмите цифру: 6");
            Console.WriteLine("Если вы хотите узнать сроки оплаты и сдачи отчётов, нажмите цифру: 7");
            int i = Convert.ToInt32(Console.ReadLine());
            switch (i)
            {
                case 1:
                    Console.WriteLine("Единый социальный взнос — обязательный взнос в общегосударственную систему социального страхования\nс целью защиты в случаях, предусмотренных законодательством, прав застрахованных\nлиц на получение страховых выплат. Не входит в систему налогообложения — порядок его начисления,\nрасчета и уплаты регулируется Государственной фискальной службой Украины. Единый социальный взнос перечисляется\nна счета налоговой инспекции, в которой зарегистрирован предприниматель.\n");
                    Console.WriteLine("Уплачивается на протяжении 19 дней, следующих за кварталом, за который производится уплата. \nРазмер социального взноса определяется предпринимателем самостоятельно,\nно не может быть меньше минимальной ставки, установленной для выбранной категории плательщика ЕСВ\n(для предпринимателей на упрощенной системе налогообложения 1-3 групп это 22% от текущей минимальной зарплаты).\n");
                    Console.WriteLine("За неуплату (неперечисление) или несвоевременную уплату (несвоевременное перечисление) единого\nвзноса предусмотрен штраф в размере 20% своевременно неуплаченных сумм.");
                    break;
                case 2:
                    Console.WriteLine("Единый налог — налог, оплачиваемый субъектами хозяйственной деятельности на упрощенной системе\nналогообложения, основной предпринимательский налог. Перечисляется в местный\nналоговый бюджет и оплачивается на счета налоговой инспекции, в которой зарегистрирован\nсубъект хозяйственной деятельности.");
                    Console.WriteLine("Уплачивается не позже 10 календарных дней, следующих за последним днем сдачи квартальной декларации\n(в течение 50 дней после окончания отчетного квартала). Размер ставки единого\nналога для третьей группы устанавливается в размере 3% от дохода за квартал для плательщиков НДС\nи 5% от дохода за квартал для неплательщиков");
                    Console.WriteLine("За неуплату единого налога предусмотрен штраф в размере 10% от неуплаченной суммы.");
                    break;
                case 3:
                    Console.WriteLine($"Отчет о суммах начисленного дохода застрахованных лиц и суммах начисленного единого взноса за {dates[2] - 1} год.\nПодается в ГФС не позже 9 февраля года, следующего за отчетным.");
                    break;
                case 4:
                    Console.WriteLine("Налоговый расчет - документ, свидетельствующий о суммах дохода, начисленного (выплаченного) в пользу\nналогоплательщиков — физических лиц, суммы удержанного и/или уплаченного налога.");
                    Console.WriteLine("Подаётся в течении 40 календарных дней, следующих за последним календарным днем отчетного квартала.");
                    break;
                case 5:
                    Console.WriteLine("Это отчет о суммах начисленной заработной платы (дохода, денежного обеспечения, помощи, компенсации)\nзастрахованных лиц и суммах начисленного единого взноса на общеобязательное\nгосударственное социальное страхование в органы доходов и сборов.");
                    Console.WriteLine("Подаётся в течении 20 календарных дней, следующих за последним днем отчетного периода.");
                    break;
                case 6:
                    Console.WriteLine("Налоговая декларация отражает заработанную предпринимателем сумму за отчетный период (сумма считается накопительно\nс начала года), а также сумму уплаченных налогов. Задекларированная сумма является основанием и\nобязательством к уплате единого налога для предпринимателей 3 группы");
                    Console.WriteLine("Подаётся в ГФС не позже 40 календарных дней, следующих за последним календарным днем отчетного квартала");
                    break;
                case 7:
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕСВ' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(20).ToShortDateString()}.");
                    Console.WriteLine("Сумма оплаты: 2 754,18 грн");
                    Console.WriteLine($"Вы должны оплатить 'Уплата ЕН' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(50).ToShortDateString()}.");
                    Console.WriteLine("Сумма оплаты: 5% от дохода");
                    Console.WriteLine($"Дата следующей сдачи 'Отчета по ЕСВ': с {DateOfFirstKvartal(dates).ToShortDateString()} до {DateOfFirstKvartal(dates).AddDays(40).ToShortDateString()}.");
                    Console.WriteLine($"Вы должны сдать 'Налоговый расчет' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(40).ToShortDateString()}");
                    Console.WriteLine($"Вы должны сдать 'Отчет о суммах начисленной заработной платы и суммах начисленного ЕСВ' через {DaysToNearMonth(dateNow, DateOfNearMonth(dates)).ToString("dd")} дней,\nа именно с {DateOfNearMonth(dates).ToShortDateString()} до {DateOfNearMonth(dates).AddDays(20).ToShortDateString()}");
                    Console.WriteLine($"Вы должны сдать 'Налоговая декларация' через {dayOfNextKvartal} дней, а именно: с {daysNextKvartal.ToShortDateString()} до {daysNextKvartal.AddDays(40).ToShortDateString()}");
                    break;
                default:
                    break;
            }
            Console.WriteLine("Желаете еще что-то узнать о ваших налогах или отчётах? Да(1), Нет(2)");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1)
            {
                repeat = true;
            }
            else
                repeat = false;
        }
    }
}
