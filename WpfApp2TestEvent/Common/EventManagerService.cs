using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp2TestEvent
{
    public class EventManagerService<TEventSource, TEventArgs> where TEventArgs : EventArgs
    {
        public static void AddHandler(TEventSource source, System.Linq.Expressions.Expression<Func<TEventSource, string>> expression, EventHandler<TEventArgs> handle)
        {
            var constant = expression.Body as System.Linq.Expressions.ConstantExpression;
            if (constant == null)
            {
                throw new ArgumentException("Expression must be a constant expression.");
            }

            AddHandler(source, constant.Value?.ToString(), handle);
        }

        public static void AddHandler(TEventSource source, string eventName, EventHandler<TEventArgs> handle)
        {
            WeakEventManager<TEventSource, TEventArgs>.AddHandler(source, eventName, handle);
        }
    }

    public class EventService
    {
        public List<EventHandler> Events { get; set; }
        public event EventHandler OldEvents;

        public EventService()
        {
            //Events[0].inv
            //OldEvents.in
        }
    }
}