using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.BLL.Abstract.Services;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Services;


public class IngredientService : IIngredientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBackMapper<Ingredient, IngredientModel> _ingredientMapper;

    public IngredientService(IUnitOfWork unitOfWork, IBackMapper<Ingredient, IngredientModel> ingredientMapper)
    {
        _unitOfWork = unitOfWork;
        _ingredientMapper = ingredientMapper;
    }

    public IngredientModel Create(IngredientModel model)
    {
        var result = _ingredientMapper.Map(_unitOfWork.IngredientRepository.Add(_ingredientMapper.MapBack(model)));
        _unitOfWork.SaveChanges();

        return model;
    }

    public List<IngredientModel> GetAll()
    {
        return _unitOfWork.IngredientRepository.GetAll(x => true).Select(_ingredientMapper.Map).ToList();

    }

    public IngredientModel GetById(int id)
    {
        return _ingredientMapper.Map(_unitOfWork.IngredientRepository.GetById(id));

    }

    public bool Update(IngredientModel model)
    {
        if (model == null)
        {
            return false;
        }
        var entity = _ingredientMapper.MapBack(model);

        var result = _unitOfWork.IngredientRepository.Update(entity);
        _unitOfWork.SaveChanges();

        return result;
    }

    public bool Delete(int id)
    {
        var result =  _unitOfWork.IngredientRepository.Delete(id);
        _unitOfWork.SaveChanges();
        return result;
    }
}