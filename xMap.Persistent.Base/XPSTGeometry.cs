using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http.Headers;
using DevExpress.Xpo;
using DevExpress.Xpo.Helpers;
using DevExpress.Xpo.Metadata;
using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Implementation;
using NetTopologySuite.IO;
using NetTopologySuite.LinearReferencing;
using xMap.Persistent.Base;

namespace xMap.Persistent.BaseImpl
{

    //https://community.devexpress.com/blogs/oliver/archive/2017/01/16/xpo-sql-server-and-spatial-data-revisited.aspx


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
        [Key(autoGenerate: true), Persistent("OBJECTID"), DbType("NUMBER(38,0)"),Browsable(false)]
        public Int64 OID
        {
            get => oid;
            set => SetPropertyValue<Int64>(nameof(OID), ref oid, value);
        }

        private Geometry shape;
        [DbType("SDE.ST_GEOMETRY"), Persistent("SHAPE")]
        [ValueConverter(typeof(GeometryConverter))]
        public Geometry Shape
        {
            get => shape;
            set => SetPropertyValue(nameof(Shape), ref shape, value);
        }

    }


    public class CustomCoordinateSequenceFactory:CoordinateSequenceFactory
    {
        private Ordinates ordinates;
        public CustomCoordinateSequenceFactory(Ordinates ordinates)
        {
            this.ordinates = ordinates;
        }

        public override CoordinateSequence Create(Coordinate[] coordinates)
        {
            //return GeometryFactory.Default.CoordinateSequenceFactory.Create(coordinates);
            return new CoordinateArraySequence(coordinates, OrdinatesUtility.OrdinatesToDimension(Ordinates));
        }

        public override CoordinateSequence Create(CoordinateSequence coordSeq)
        {
            return GeometryFactory.Default.CoordinateSequenceFactory.Create(coordSeq);
        }

        public override CoordinateSequence Create(int size, Ordinates ordinates)
        {
            return GeometryFactory.Default.CoordinateSequenceFactory.Create(size, ordinates);
        }
        public override CoordinateSequence Create(int size, int dimension, int measures)
        {
            return this.Create(size, this.Ordinates);
        }

        public new Ordinates Ordinates => ordinates;

    }

    public class GeometryConverter : ValueConverter
    {


        public static Geometry FromWKT(string value,int srid=25832)
        {

            //SqlChars str = new SqlChars(new SqlString((string)value));

            var wkt = (string)value;

            WKTReader reader = null;

            var tokens = new string(wkt.TakeWhile(c => c != '(').ToArray()).Split(' ');
            if (tokens.Length > 0)
            {
                switch (tokens[1])
                {
                    case "M":
                        reader = new WKTReader(new GeometryFactory(new CustomCoordinateSequenceFactory(Ordinates.XYM)));
                        break;
                    case "Z":
                        reader = new WKTReader(new GeometryFactory(new CustomCoordinateSequenceFactory(Ordinates.XYZ)));
                        break;
                    case "ZM":
                        reader = new WKTReader(new GeometryFactory(new CustomCoordinateSequenceFactory(Ordinates.XYZM)));
                        break;
                    default:
                        break;
                }
            }
            if (reader == null)
                reader = new WKTReader();
            Geometry g = reader.Read((string)value);
            g.SRID = srid;

            return g;

            //WKTWriter writer = WKTWriter.ForMicrosoftSqlServer();
            //var ss = writer.Write(g);
            //SqlChars str = new SqlChars(ss);
            //SqlGeometry s = SqlGeometry.STGeomFromText(str, 25832);


            //return s;
        }

        public override object ConvertFromStorageType(object value)
        {
            return GeometryConverter.FromWKT(value as string);
        }

        public override object ConvertToStorageType(object value)
        {
            if (value == null) return null;

            // this mechanism persists the srid to SQL Server - 
            // better than using WKT because it doesn't contain srid at all
            var geometry = value as Geometry;
            if (geometry != null)
                value = geometry.AsText();

            //var sqlGeography = value as SqlGeography;
            //if (sqlGeography != null)
            //    value = sqlGeography.STAsText().ToSqlString().ToString();
            //else
            //{
            //    var sqlGeometry = value as SqlGeometry;
            //    if (sqlGeometry != null)
            //        value = sqlGeometry.STAsText().ToSqlString().ToString();
            //}

            return value;
        }
        public override Type StorageType
        {
            get { return typeof(string); }
        }
    }

}
