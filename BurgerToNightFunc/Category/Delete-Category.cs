using System.Net;
using AutoMapper;
using BurgerToNightAPI.Data;
using BurgerToNightAPI.Repository.IRepository;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace BurgerToNightFunc.Category
{
    public class Delete_Category
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public Delete_Category(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


    }
}
