using BookInformationService.Models;

namespace BookInformationService.DataAccessLayer
{
    public interface IBookInformationDL
    {
        Task<int> CreateBookInformation(BookInformation bookInformation);
        Task<int> DeleteBookInformation(BookInformation bookInformation);
        Task<BookInformation?> GetBookInformation(int id);
        Task<List<BookInformation>?> GetBookInformations();
        Task<List<BookInformation>?> SearchBookInformations(string searchTerm);
        Task<int> UpdateBookInformation(BookInformation bookInformation);
    }
}