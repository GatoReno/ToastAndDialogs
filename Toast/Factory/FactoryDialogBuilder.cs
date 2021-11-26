using System;
using Android.Content;
using Toast.Abstractions;
using Toast.Enums;
using Toast.Service;

namespace Toast.Factory
{
    
    internal class SingletonDialogBuilder : IDialogBuilder, IDialogService
    {
        private string _title, _message, _positiveLabel, _negativeLabel;
        private Action _positiveAction, _negativeAction;

        EventHandler<DialogClickEventArgs> _actionPositive;
        EventHandler<DialogClickEventArgs> _actionNegative;

        AndroidX.AppCompat.App.AlertDialog.Builder dialog;

        internal SingletonDialogBuilder()
        {
            _actionNegative += OnActionNegative;
            _actionPositive += OnActionPositive;
        }

        void OnActionNegative(object sender, DialogClickEventArgs e)
        {
            _negativeAction?.Invoke();
        }

        void OnActionPositive(object sender, DialogClickEventArgs e)
        {
            _positiveAction?.Invoke();
        }

        public static AndroidX.AppCompat.App.AlertDialog.Builder CreateAlertDialog
            (Context context,
            string title,
            string message,
            string positiveLabel,
            DialogAlerts type,
            EventHandler<DialogClickEventArgs> actionPositive,
            EventHandler<DialogClickEventArgs> actionNegative
            )
        {
            AndroidX.AppCompat.App.AlertDialog.Builder dialog =
                new AndroidX.AppCompat.App.AlertDialog.Builder(ServiceInitializer.Instance.Context);
            dialog.SetTitle(title)
                  .SetMessage(message)
                  .SetIcon(null)
                  .SetMessage("")
                  .Show();

            if (type == DialogAlerts.OnlyPositive)
            {
                dialog.SetPositiveButton(positiveLabel, actionPositive);
            }
            if (type == DialogAlerts.PositiveAndNegative)
            {
                dialog.SetNegativeButton("Cancel", actionNegative);
            }            

            return dialog;
        }



        #region IDialogService

        public void ShowDialog()
        {
            dialog.Show();
        }
        #endregion region


        #region IDialogBuilder
        public IDialogService BuildDiaalog()
        {
            dialog = new AndroidX.AppCompat.App.AlertDialog.Builder(ServiceInitializer.Instance.Context)
                .SetTitle(_title)
                .SetMessage(_message)
                .SetPositiveButton(_positiveLabel, _actionPositive)
                .SetNegativeButton(_negativeLabel, _actionNegative)
                ;

            return this;

        }

      

        public IDialogBuilder SetMessage(string message)
        {
            _message = message;
            return this;
        }

        public IDialogBuilder SetNegativeAction(Action actionNegative)
        {
            _negativeAction = actionNegative;
            return this;
        }

        public IDialogBuilder SetPositiveAction(Action actionPositive)
        {
            _positiveAction = actionPositive;
            return this;
        }

        public IDialogBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public IDialogBuilder SetPositiveLabel(string positive)
        {
            _positiveLabel = positive;
            return this;
        }

        public IDialogBuilder SetNegativeLabel(string negative)
        {
            _negativeLabel = negative;
            return this;
        }



        #endregion
    }
}
