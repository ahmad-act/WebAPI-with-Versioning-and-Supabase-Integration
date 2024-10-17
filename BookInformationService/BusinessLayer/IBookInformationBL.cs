using BookInformationService.DTOs;
using BookInformationService.Models;

namespace BookInformationService.BusinessLayer
{
    public interface IBookInformationBL
    {
        Task<BookInformationDisplayDto?> CreateBookInformation(BookInformationUpdateDto bookInformationUpdateDto);
        Task<string> DeleteBookInformation(int id);
        Task<BookInformationDisplayDto?> GetBookInformation(int id);
        Task<List<BookInformationDisplayDto>?> GetBookInformations();
        Task<List<BookInformationDisplayDto>?> SearchBookInformations(string searchTerm);
        Task<BookInformationDisplayDto?> UpdateBookInformation(int id, BookInformationUpdateDto bookInformationUpdateDto);
    }
}