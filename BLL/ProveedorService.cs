using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL;

namespace BLL
{
    public class ProveedorService
    {
        private ProveedorDAL _proveedorDal;

        public ProveedorService()
        {
            _proveedorDal = new ProveedorDAL();
        }

        public Proveedor BuscarId(int id)
        {
            return _proveedorDal.BuscarId(id);
        }
        public List<Proveedor> ListarProveedores()
        {
            return _proveedorDal.ListarProveedores();
        }
        public void AgregarProveedor(Proveedor proveedor)
        {
            _proveedorDal.AgregarProveedor(proveedor);
        }
        public void ActualizarProveedor(Proveedor proveedor)
        {
            if (_proveedorDal.BuscarId(proveedor.Id) == null)
                throw new Exception("No existe el proveedor");

            _proveedorDal.ActualizarProveedor(proveedor);
        }
        public void EliminarProveedor(int id)
        {
            if (_proveedorDal.BuscarId(id) == null)
                throw new Exception("No existe el id");

            _proveedorDal.EliminarProveedor(id);
        }
    }
}
