using UnityEngine;
using UnityEngine.UI;

public class PageNavigation : MonoBehaviour
{
    public Button nextButton;
    public Button prevButton;

    private int currentPage = 0;
    private int maxPage = 4; // Change this to the number of pages you have.

    private void Start()
    {
        // Attach click event handlers to the buttons.
        nextButton.onClick.AddListener(NextPage);
        prevButton.onClick.AddListener(PreviousPage);

        // Initially, disable the prevButton since you can't go back from the first page.
        prevButton.interactable = false;
    }

    private void NextPage()
    {
        currentPage++;
        // Update your game content for the next page here.

        // Disable the nextButton when you reach the last page.
        if (currentPage >= maxPage - 1)
        {
            nextButton.interactable = false;
        }

        // Enable the prevButton when you're not on the first page.
        if (currentPage > 0)
        {
            prevButton.interactable = true;
        }
    }

    private void PreviousPage()
    {
        currentPage--;
        // Update your game content for the previous page here.

        // Disable the prevButton when you're on the first page.
        if (currentPage <= 0)
        {
            prevButton.interactable = false;
        }

        // Enable the nextButton when you're not on the last page.
        if (currentPage < maxPage - 1)
        {
            nextButton.interactable = true;
        }
    }
}
