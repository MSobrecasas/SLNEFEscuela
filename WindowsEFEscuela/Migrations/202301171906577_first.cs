namespace WindowsEFEscuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        IdAlumno = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        FechaNacimento = c.DateTime(),
                        IdProf = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAlumno)
                .ForeignKey("dbo.Docente", t => t.IdProf, cascadeDelete: true)
                .Index(t => t.IdProf);
            
            CreateTable(
                "dbo.Docente",
                c => new
                    {
                        ProfesorId = c.Int(nullable: false, identity: true),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Titulo = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ProfesorId);
            
            CreateTable(
                "dbo.Aula",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Capacidad = c.Int(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Programa = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumno", "IdProf", "dbo.Docente");
            DropIndex("dbo.Alumno", new[] { "IdProf" });
            DropTable("dbo.Materia");
            DropTable("dbo.Aula");
            DropTable("dbo.Docente");
            DropTable("dbo.Alumno");
        }
    }
}
