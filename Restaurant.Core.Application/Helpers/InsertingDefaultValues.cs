using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Application.ViewModels.Table;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Helpers
{
    public class InsertingDefaultValues
    {



        public static async Task InsertingDefault(ITableStatusRepository _TableStatus, IOrderStatusRepository _OrderStatus, IDishCategoryRepository _dishCategory) {

            var TableStat = await _TableStatus.GetAllViewModel();
            var OrderStat = await _OrderStatus.GetAllViewModel();
            var DishCategory = await _dishCategory.GetAllViewModel();

            if (TableStat == null || TableStat.Count == 0 && OrderStat == null || OrderStat.Count == 0 && DishCategory == null || DishCategory.Count == 0)
            {
                string[] TableS = { "Disponible", "En proceso de atención" , "Atendida" };
                string[] OrderS = { "En proceso", "Completada" };
                string[] DishC = { "Entrada", "Plato fuerte", "Postre", "Bebida" };

                int i = 0;
                int j = 0;
                int k = 0;

                foreach (string s in TableS)
                {
                    TableStatus tableStatus = new();
                    tableStatus.status = TableS[i];

                    await _TableStatus.AddAsync(tableStatus);
                    i++;
                }

                foreach (string s in OrderS)
                {
                    OrderStatus orderStatus = new();
                    orderStatus.status = OrderS[j];

                    await _OrderStatus.AddAsync(orderStatus);
                    j++;
                }

                foreach (string s in DishC)
                {
                    DishCategory dishCategory = new();
                    dishCategory.Name = DishC[k];

                    await _dishCategory.AddAsync(dishCategory);
                    k++;
                }
            }

        }
    }
}
