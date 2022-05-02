using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.BLL.Abstract.Services;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Services;


public class DishIngredientService : IDishIngredientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBackMapper<DishIngredient, DishIngredientModel> _dishIngredientMapper;

    public DishIngredientService(IUnitOfWork unitOfWork, IBackMapper<DishIngredient, DishIngredientModel> dishIngredientMapper)
    {
        _unitOfWork = unitOfWork;
        _dishIngredientMapper = dishIngredientMapper;
    }

    public DishIngredientModel Create(DishIngredientModel model)
    {
        var result = _dishIngredientMapper.Map(_unitOfWork.DishIngredientRepository.Add(_dishIngredientMapper.MapBack(model)));
        _unitOfWork.SaveChanges();
        
        // _unitOfWork.Dispose();

        return model;
    }

    public List<DishIngredientModel> GetAll()
    {
        var result = _unitOfWork.DishIngredientRepository.GetAll(x => true).Select(_dishIngredientMapper.Map).ToList();
        
        // _unitOfWork.Dispose();
        return result;
    }

    public DishIngredientModel GetById(int id)
    {
        var result =_dishIngredientMapper.Map(_unitOfWork.DishIngredientRepository.GetById(id));
        
        // _unitOfWork.Dispose();
        return result;
    }

    public bool Update(DishIngredientModel model)
    {
        if (model == null)
        {
            return false;
        }
        var entity = _dishIngredientMapper.MapBack(model);

        var result = _unitOfWork.DishIngredientRepository.Update(entity);
        _unitOfWork.SaveChanges();

        // _unitOfWork.Dispose();
        
        return result;
    }

    public bool Delete(int id)
    {
        var result =  _unitOfWork.DishIngredientRepository.Delete(id);
        _unitOfWork.SaveChanges();
        
        
        // _unitOfWork.Dispose();
        
        return result;
    }
}