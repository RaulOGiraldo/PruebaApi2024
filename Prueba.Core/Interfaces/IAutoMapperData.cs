using PostgresSql.Data;
using Prueba.Core.DTOs;

namespace Prueba.Core.Interfaces
{
    public interface IAutoMapperData
    {
        List<UsersInRolesDTO> MapearUsersInRoles(List<User> listado);
        UsersInRolesDTO MapearUserInRol(User user);
        User DevolverUsersInRoles(UserCreacionDTO userCreacionDTO);

        List<TransactionDTO> MapearTransactions(List<Transaction> listTransac);
        TransactionDTO MapearOneTransaction(Transaction transac);
        Transaction ConsultaDataTransaction(TransactionCreacionDTO transacCreacionDTO, Product product, User user);
        ProductDTO MapearProducts(Product prod);
        TransactionUserDTO MapearUserTransctions(User user);

        bool BuscarPermisos(User user, int mode = 0);
        decimal ValidarSaldo(Product prod, TransactionCreacionDTO trans);
    }
}
