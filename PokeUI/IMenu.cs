namespace PokeUI
{

    /* 
    Interface is best was to implement abstraction.
    > every method is implicitly abstract
    >every method is public        
    
     */
    public interface IMenu
    {
        /// <summary>
        /// will display the menu and user choice in the terminal
        /// </summary>

        //we do not have to put that the method is public B/C 
        // all the methods will be public
        void Display();

        /// <summary>
        /// will record the user's choice and change/route your menu based on that 
        /// </summary>
        /// <returns>Return the  menu that will change your screen</returns>
        string UserChoice();
    }
}