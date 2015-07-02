using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using mvvm_light_sample.Common;

namespace mvvm_light_sample.Model
{
    public class ProgressModel
    {
        public static ProgressParameter ProgressAction1()
        {
            var parameter = new ProgressParameter()
            {
                IsIndeterminate = false,
                Max = 50,
                Message = "処理中です"
            };

            parameter.ProgressAction = (tokenSource) =>
            {
                for (int i = 0; i < 50; i++)
                {
                    parameter.Value++;  // 進捗++

                    // キャンセルしたかどうか
                    if (tokenSource.IsCancellationRequested)
                        break;

                    System.Threading.Thread.Sleep(100);
                    Debug.WriteLine(i.ToString());
                }
            };

            return parameter;
        }

        public static ProgressParameter ProgressAction2()
        {
            var parameter = new ProgressParameter()
            {
                IsIndeterminate = true,
                Message = "処理中です"
            };

            parameter.ProgressAction = (tokenSource) =>
            {
                for (int i = 0; i < 50; i++)
                {

                    // キャンセルしたかどうか
                    if (tokenSource.IsCancellationRequested)
                        break;

                    System.Threading.Thread.Sleep(100);
                    Debug.WriteLine(i.ToString());
                }
            };

            return parameter;
        }

    }
}
