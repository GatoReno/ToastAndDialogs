using System;
namespace Toast.Abstractions
{
    public interface IDialogService
    {
        void ShowDialog();
    }

    public interface IDialogBuilder 
    {
        IDialogBuilder SetTitle(string title);
        IDialogBuilder SetMessage(string message);
        IDialogBuilder SetPositiveLabel(string positive);
        IDialogBuilder SetNegativeLabel(string negative);
        IDialogBuilder SetPositiveAction(Action actionPositive);
        IDialogBuilder SetNegativeAction(Action actionNegative);
        IDialogService BuildDiaalog();
    }
}
