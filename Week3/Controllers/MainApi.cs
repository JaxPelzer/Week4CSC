using Microsoft.AspNetCore.Mvc;

namespace Week3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainApi : ControllerBase
    {



        [HttpPost(Name = "GetStandardDeviation")]
        public ActionResult<List<string>> intList(List<int> lint)
        {
            List<string> list1 = new List<string>();
            List<int> list2 = new List<int>();
            double sum, counter = 0, mean = 0, StSum, Stdev;
            LogObject(lint);
            lint.Sort();

            foreach (int i in lint)
            {
                counter++;
                sum = 0;
                StSum = 0;
                list2.Add(i);
                                      
                
                if (counter > 1) {
                    foreach (int j in list2)
                    {                   
                        sum += j;
                        mean = sum / counter;                    
                    }
                    foreach (int k in list2)
                    {
                        StSum += Math.Pow(k - mean, 2);
                    }
                    Stdev = Math.Sqrt(StSum / (counter - 1));
                    list1.Add("Elements: " + counter + " Currunt Standard Devation : " + Stdev);
                } else
                {
                    list1.Add("List to small");
                }

            }

            

            return list1;
        }
        void LogObject(List<int> input)
        {
            for (int i =0; i < input.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(input[i]);
            }
            

        }
    }
}