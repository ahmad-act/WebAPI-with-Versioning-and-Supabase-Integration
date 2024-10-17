using AutoMapper;
using BookInformationService.DataAccessLayer;
using BookInformationService.DTOs;
using BookInformationService.Models;
using System.Collections.Generic;

namespace BookInformationService.BusinessLayer
{
    public class BookInformationBL : IBookInformationBL
    {
        private readonly ILogger<object> _logger;
        private readonly IBookInformationDL _bookInformationDL;
        private readonly IMapper _mapper;

        public BookInformationBL(ILogger<object> logger, IBookInformationDL bookInformationDL, IMapper mapper)
        {
            _logger = logger;
            _bookInformationDL = bookInformationDL;
            _mapper = mapper;
        }

        public async Task<List<BookInformationDisplayDto>?> GetBookInformations()
        {
            List<BookInformation>? bookInformations = await _bookInformationDL.GetBookInformations();

            if (bookInformations == null)
            {
                return null;
            }
            else
            {
                return bookInformations.Select(b => _mapper.Map<BookInformationDisplayDto>(b)).ToList();
            }
        }

        public async Task<BookInformationDisplayDto?> GetBookInformation(int id)
        {
            BookInformation? bookInformation = await _bookInformationDL.GetBookInformation(id);

            if (bookInformation == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map<BookInformationDisplayDto>(bookInformation);
            }
        }

        public async Task<BookInformationDisplayDto?> CreateBookInformation(BookInformationUpdateDto bookInformationUpdateDto)
        {
            BookInformation? bookInformation = _mapper.Map<BookInformation>(bookInformationUpdateDto);
            bookInformation.Available = bookInformationUpdateDto.Stock;

            int result = await _bookInformationDL.CreateBookInformation(bookInformation);
            return _mapper.Map<BookInformationDisplayDto>(bookInformation);
        }

        public async Task<BookInformationDisplayDto?> UpdateBookInformation(int id, BookInformationUpdateDto bookInformationUpdateDto)
        {
            if (bookInformationUpdateDto == null)
            {
                return null;
            }

            var existingBookInformation = await _bookInformationDL.GetBookInformation(id);

            if (existingBookInformation == null)
            {
                return null;
            }

            existingBookInformation.Title = bookInformationUpdateDto.Title;
            existingBookInformation.Stock = bookInformationUpdateDto.Stock;

            int result = await _bookInformationDL.UpdateBookInformation(existingBookInformation);

            return _mapper.Map<BookInformationDisplayDto>(existingBookInformation);
        }

        public async Task<string> DeleteBookInformation(int id)
        {
            var bookInformation = await _bookInformationDL.GetBookInformation(id);

            if (bookInformation == null)
            {
                return "Book info not found";
            }

            int result = await _bookInformationDL.DeleteBookInformation(bookInformation);

            return string.Empty;
        }

        public async Task<List<BookInformationDisplayDto>?> SearchBookInformations(string searchTerm)
        {
            List<BookInformation>? bookInformations = await _bookInformationDL.SearchBookInformations(searchTerm);

            if (bookInformations == null)
            { 
                return null; 
            }
            else
            {
                return bookInformations.Select(b => _mapper.Map<BookInformationDisplayDto>(b)).ToList();
            }
            
        }
    }
}
