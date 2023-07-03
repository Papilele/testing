using Newtonsoft.Json;
using System;
using Pastel;

namespace testing
{
    class Program
    {
        

        static async Task Main(string[] args)
        {
            string url = "https://raw.githubusercontent.com/Papilele/testing/main/stages.json";

            HttpClient httpClient = new();

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);

                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonResponse);

                var myStages = JsonConvert.DeserializeObject<Stage[]>(jsonResponse);

                Console.WriteLine("                     Процесс согласования документа \n\n" +
                    " Введите 'y(yes)' если согласовано, либо 'n(no) если не согласовано' \n" +
                    "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ \n");

                List<string> tableStage = new List<string>();
                List<string> tablePerformer = new List<string>();
                List<string> tableResult = new List<string>();
                List<string> tableComment = new List<string>();


                foreach (var stage in myStages)
                {
                    Console.WriteLine($" Наименование этапа: {stage.Name} \n" +
                        $" Согласующий: {stage.Performer}");
                    tableStage.Add(stage.Name);
                    tablePerformer.Add(stage.Performer);

                    Console.Write(" Согласовано: ");
                    string? result = Console.ReadLine();
                    if (result == "y")
                    {
                        tableResult.Add("Согласовано".Pastel("#32CD32"));	
                    } else if (result == "n")
                    {
                        tableResult.Add("Не согласовано".Pastel("#FF0000"));
                    } else
                    {
                        tableResult.Add("Пропущено".Pastel("#1E90FF"));
                    }


                    Console.Write(" Комментарий: ");
                    string? comment = Console.ReadLine();
                    if (comment == "")
                    {
                        tableComment.Add("              ");
                    } else
                    {
                        tableComment.Add(comment);
                    }
                    

                    Console.WriteLine("\n_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _\n");

                }


                Console.WriteLine("                            Таблица согласования\n" +
                    "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _\n\n"+
                    " |   Наименование этапа   |  Согласующий  | Результат | Комментарий |\n" +
                    "_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _\n");
                for (int i = 0; i < tableStage.Count; i++)
                {
                    Console.WriteLine($" | {tableStage[i]} | {tablePerformer[i]} | {tableResult[i]} | {tableComment[i]} |\n_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _\n");
                }

                Console.WriteLine("colorize me".Pastel("#1E90FF"));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                httpClient.Dispose();
            }
        }
    }
}

