using Restaurant62.BLL.Abstract.Mappers;
using Restaurant62.BLL.Abstract.Services;
using Restaurant62.DAL.Abstract.Repository.Base;
using Restaurant62.DAL.Impl.Repository;
using Restaurant62.Entities;
using Restaurant62.Models;

namespace Restaurant62.BLL.Impl.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBackMapper<Order, OrderModel> _orderMapper;


    public OrderService(IUnitOfWork unitOfWork, IBackMapper<Order, OrderModel> orderMapper)
    {
        _unitOfWork = unitOfWork;
        _orderMapper = orderMapper;
    }

    public OrderModel Create(OrderModel model)
    {
        GetOrderPrice(model);


        _orderMapper.Map(_unitOfWork.OrderRepository.Add(_orderMapper.MapBack(model)));
        _unitOfWork.SaveChanges();

        return model;
    }

    public List<OrderModel> GetAll()
    {
        return _unitOfWork.OrderRepository.GetAll(x => true).Select(_orderMapper.Map).ToList();
    }

    public OrderModel GetById(int id)
    {
        return _orderMapper.Map(_unitOfWork.OrderRepository.GetById(id));
    }

    public bool Update(OrderModel model)
    {
        if (model == null)
        {
            return false;
        }
        
        GetOrderPrice(model);

        var entity = _orderMapper.MapBack(model);

        var result = _unitOfWork.OrderRepository.Update(entity);
        _unitOfWork.SaveChanges();

        return result;
    }

    public bool Delete(int id)
    {
        var result = _unitOfWork.OrderRepository.Delete(id);
        _unitOfWork.SaveChanges();

        return result;
    }

    public void GetOrderPrice(OrderModel model)
    {
        decimal? result = 0;
        List<DishOrder> list = _unitOfWork.DishOrderRepository.GetAll(x => x.OrderId == model.OrderId);

        // var dishlist = _unitOfWork.DishRepository.GetAll(x => x.DishId == list.dishId);


        foreach (var item in list)
        {
            result += _unitOfWork.DishRepository.GetById(item.DishId).FinalPrice;
        }

        model.OrderPrice = result;
    }
}