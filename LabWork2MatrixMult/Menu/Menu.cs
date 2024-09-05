using LabWork2MatrixMult.ClassesLibrary;

namespace LabWork2MatrixMult.Menu;
public class Menu
{
    readonly Matrix[] matrices = MenuHandler.GenerateMatricesOptions();
    public void Start()
    {
        while (true)
        {
            matrices[2].FillZero();
            MenuHandler.WriteOptions();
            int option = MenuHandler.ReadOption();
            if (option == 0)
            {
                break;
            }

            MenuHandler.HandleOption(option, matrices[0], matrices[1], matrices[2]);
            Console.ReadLine();
        }
    }

}