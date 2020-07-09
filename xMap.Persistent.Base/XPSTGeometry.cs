using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using Microsoft.SqlServer.Types;
using xMap.Persistent.Base;

namespace xMap.Persistent.BaseImpl
{
    [NonPersistent]
    [DeferredDeletion(false)]
    [OptimisticLocking(false)]
    public abstract class XPSTGeometry:XPCustomObject,IXPGeometry
    {
        public XPSTGeometry():base(Session.DefaultSession)
        {

        }

        public XPSTGeometry(Session session):base(session)
        {

        }

        private Int64 oid;
        [Key(autoGenerate: false), Persistent("OBJECTID"), DbType("NUMBER(*,0)")]
        public Int64 OID
        {
            get => oid;
            set => SetPropertyValue<Int64>(nameof(OID), ref oid, value);
        }

        private SqlGeometry shape;
        [DbType("SDE.ST_GEOMETRY"), Persistent("SHAPE")]
        [ValueConverter(typeof(GeometryConverter))]
        public SqlGeometry Shape
        {
            get => shape;
            set => SetPropertyValue(nameof(Shape), ref shape, value);
        }

    }

    public class GeometryConverter : ValueConverter
    {
        public override object ConvertFromStorageType(object value)
        {
            // We're ignoring the request to convert here, knowing that the loaded
            // object is already the correct type because SqlClient returns it 
            // that way.

            //byte[] buff = value as byte[];
            //SqlBytes bytes = new SqlBytes(buff);
            //var s = SqlGeometry.STGeomFromWKB(bytes,25832);

            SqlChars str = new SqlChars(new SqlString((string)value));
            var s = SqlGeometry.STGeomFromText(str, 25832);


            return s;
        }

        public override object ConvertToStorageType(object value)
        {
            if (value == null) return null;

            // this mechanism persists the srid to SQL Server - 
            // better than using WKT because it doesn't contain srid at all
            var sqlGeography = value as SqlGeography;
            if (sqlGeography != null)
                value = sqlGeography.STAsText().ToSqlString().ToString();
            else
            {
                var sqlGeometry = value as SqlGeometry;
                if (sqlGeometry != null)
                    value = sqlGeometry.STAsText().ToSqlString().ToString();
            }
            return value;
        }
        public override Type StorageType
        {
            get { return typeof(string); }
        }
    }

}
