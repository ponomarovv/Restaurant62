using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Services;


public class PricelistService : IPriceListService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBackMapper<Pricelist, PricelistModel> _priceListMapper;

    public PricelistService(IUnitOfWork unitOfWork, IBackMapper<Pricelist, PricelistModel> priceListMapper)
    {
        _unitOfWork = unitOfWork;
        _priceListMapper = priceListMapper;
    }

    public PricelistModel Create(PricelistModel model)
    {
        var result = _priceListMapper.Map(_unitOfWork.PriceListRepository.Add(_priceListMapper.MapBack(model)));
        _unitOfWork.SaveChanges();

        return model;
    }

    public List<PricelistModel> GetAll()
    {
        return _unitOfWork.PriceListRepository.GetAll(x => true).Select(_priceListMapper.Map).ToList();

    }

    public PricelistModel GetById(int id)
    {
        return _priceListMapper.Map(_unitOfWork.PriceListRepository.GetById(id));
    }

    public bool Update(PricelistModel model)
    {
        if (model == null)
        {
            return false;
        }
        var entity = _priceListMapper.MapBack(model);

        var result = _unitOfWork.PriceListRepository.Update(entity);
        _unitOfWork.SaveChanges();

        return result;
    }

    public bool Delete(int id)
    {
        var result =  _unitOfWork.PriceListRepository.Delete(id);
        _unitOfWork.SaveChanges();
        
        return result;
    }
}