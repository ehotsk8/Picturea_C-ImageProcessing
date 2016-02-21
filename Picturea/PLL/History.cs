using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLL
{
    public class History
    {
        public class HistoryItem
        {
            public string Action { get; private set; }
            public Picture Picture { get; private set; }

            public HistoryItem(string Action)
            {
                this.Action = Action;
                Picture = new Picture(Layers.CurrentLayer.Foreground.EditImage);
            }
        }

        public event ChangeEvent SomeEvent;
        public delegate void ChangeEvent();

        public static int CurrentId { get; set; }

        public static List<HistoryItem> HistoryList { get; private set; }

        /// <summary>
        /// История действий.
        /// </summary>
        public History()
        {
            HistoryList = new List<HistoryItem>();
        }

        /// <summary>
        /// Сохранение в историю.
        /// </summary>
        /// <param name="Action"></param>
        public void Add(string action)
        {
            if (CurrentId > 0 && CurrentId != HistoryList.Count - 1)
            {
                if (HistoryList.Count > CurrentId + 1)
                    HistoryList.RemoveRange(CurrentId + 1, HistoryList.Count - CurrentId - 1);
            }

            if (CurrentId == 0 && HistoryList.Count > 0)
            {
                HistoryList.RemoveRange(1, HistoryList.Count - 1);
            }

            HistoryList.Add(new HistoryItem(action));
            CurrentId++;

            if (SomeEvent != null)
                SomeEvent();
        }

        /// <summary>
        /// Отмена действия
        /// </summary>
        public void Undo()
        {
            if (HistoryList.Count > 1 && CurrentId > 1)
            {
                CurrentId--;
                if (SomeEvent != null)
                    SomeEvent();
            }
        }

        /// <summary>
        /// Возвращает предыдущее изменение
        /// </summary>
        public void Redo()
        {
            if (HistoryList.Count > 1 && CurrentId < HistoryList.Count)
            {
                CurrentId++;
                if (SomeEvent != null)
                    SomeEvent();
            }
        }
    }
}
