using System;
using Android.Content;
using Toast.Abstractions;
using Toast.Enums;
using Toast.Service;

namespace Toast.Factory
{
    
    internal class SingletonDialogBuilder : IDialogBuilder, IDialogService
    {
        #region props
        private string _title, _message, _positiveLabel, _negativeLabel;
        private Action _positiveAction, _negativeAction;

        EventHandler<DialogClickEventArgs> _actionPositive;
        EventHandler<DialogClickEventArgs> _actionNegative;

        AndroidX.AppCompat.App.AlertDialog.Builder dialog;

        #endregion

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
       
        #region IDialogService

        public void ShowDialog()
        {
            dialog.Show();
        }
        #endregion region

        #region IDialogBuilder
        public IDialogService BuildDiaalog()
        {
            if (dialog == null)
            {
                dialog = new AndroidX.AppCompat.App.AlertDialog.Builder(ServiceInitializer.Instance.Context);
            }
                dialog
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
