using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.BLL.Abstract.Services;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Services;

public class DishService : IDishService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBackMapper<Dish, DishModel> _dishMapper;


    public DishService(IUnitOfWork unitOfWork, IBackMapper<Dish, DishModel> dishMapper)
    {
        _unitOfWork = unitOfWork;
        _dishMapper = dishMapper;
    }

    public DishModel Create(DishModel model)
    {
        GetFinalPrice(model);
        
        var result = _dishMapper.Map(_unitOfWork.DishRepository.Add(_dishMapper.MapBack(model)));
        _unitOfWork.SaveChanges();


        return model;
    }

    public List<DishModel> GetAll()
    {
        var result = _unitOfWork.DishRepository.GetAll(x => true).Select(_dishMapper.Map).ToList();

        return result;
    }

    public DishModel GetById(int id)
    {
        var result = _dishMapper.Map(_unitOfWork.DishRepository.GetById(id));

        return result;
    }

    public bool Update(DishModel model)
    {
        if (model == null)
        {
            return false;
        }
        
        GetFinalPrice(model);

        var entity = _dishMapper.MapBack(model);

        var result = _unitOfWork.DishRepository.Update(entity);
        _unitOfWork.SaveChanges();


        return result;
    }

    public bool Delete(int id)
    {
        var result = _unitOfWork.DishRepository.Delete(id);
        _unitOfWork.SaveChanges();



        return result;
    }

    private void GetFinalPrice(DishModel model)
    {
        model.FinalPrice = model.PricePer100G * (decimal)model.Potion / 100;
    }
}