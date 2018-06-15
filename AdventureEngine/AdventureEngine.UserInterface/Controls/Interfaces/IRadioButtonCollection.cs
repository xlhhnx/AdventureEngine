using System.Collections.Generic;

namespace AdventureEngine.UserInterface.Controls
{
    public interface IRadioButtonCollection : IControl
    {
        IRadioButton Selected { get; set; }
        List<IRadioButton> RadioButtons { get; set; }
    }
}