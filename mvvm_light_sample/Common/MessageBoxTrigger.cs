using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace mvvm_light_sample.Common
{
    // Messenger が MessageBoxMessage を受信したときに反応するトリガー。
    public class MessageBoxTrigger : TriggerBase<DependencyObject>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            // MessageBoxMessage を受信したらアクションを実行
            // AssociatedObject は添付プロパティでこのトリガーを設定したオブジェクト。
            Messenger.Default.Register<MessageBoxMessage>(
                AssociatedObject,
                msg => InvokeActions(msg));
        }

        protected override void OnDetaching()
        {
            Messenger.Default.Unregister<MessageBoxMessage>(AssociatedObject);

            base.OnDetaching();
        }
    }
}
