using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.BLL.Abstract.Services;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Services;


public class DishOrderService : IDishOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBackMapper<DishOrder, DishOrderModel> _dishEntityMapper;


    public DishOrderService(IUnitOfWork unitOfWork, IBackMapper<DishOrder, DishOrderModel> dishEntityMapper)
    {
        _unitOfWork = unitOfWork;
        _dishEntityMapper = dishEntityMapper;
    }

    public DishOrderModel Create(DishOrderModel model)
    {
        var result = _dishEntityMapper.Map(_unitOfWork.DishOrderRepository.Add(_dishEntityMapper.MapBack(model)));
        _unitOfWork.SaveChanges();
        

        return model;
    }

    public List<DishOrderModel> GetAll()
    {
        var result = _unitOfWork.DishOrderRepository.GetAll(x => true).Select(_dishEntityMapper.Map).ToList();
        
        return result;
    }

    public DishOrderModel GetById(int id)
    {
        var result =_dishEntityMapper.Map(_unitOfWork.DishOrderRepository.GetById(id));
        
        return result;
    }

    public bool Update(DishOrderModel model)
    {
        if (model == null)
        {
            return false;
        }
        var entity = _dishEntityMapper.MapBack(model);

        var result = _unitOfWork.DishOrderRepository.Update(entity);
        _unitOfWork.SaveChanges();

        
        return result;
    }

    public bool Delete(int id)
    {
        var result =  _unitOfWork.DishOrderRepository.Delete(id);
        _unitOfWork.SaveChanges();
        
        
        
        return result;
    }
}