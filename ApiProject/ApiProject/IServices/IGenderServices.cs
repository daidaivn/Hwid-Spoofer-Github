using ApiProject.Models;


namespace ApiProject.IServices

{
    public interface IGenderServices
    {
        IQueryable<dynamic> getAllGender();
        dynamic CreateGender(Gender gender);
        dynamic UpdateGender(Gender gender);
        IQueryable<dynamic> SearchByGenderName(Gender gender);
        dynamic SearchGenderById(Gender gender);
    }
}
