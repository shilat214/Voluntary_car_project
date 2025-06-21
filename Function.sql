--1 צרי פונקצייה שתקבל קוד מתנדב ותחזיר כמה שעות חודשיות נותרו לו 
--החודש
use [D:\C# סמסטר ב\VOLUNTARY_CAR_PROJECT\VOLUNTARY_CAR_DB.MDF]
create function CountHourMonth(@idVolunteer NCHAR(9))
 returns int
 as begin
 declare @AllHourMonth int
 declare @Hour int
 select @AllHourMonth= SUM(MonthlyHours) from VolunteerServices
 where @idVolunteer=IdVolunteer
 select  @Hour= SUM(RequestedHours) from Requests r join Assignments a on(a.IdRequest=r.IdRequest)
 where @idVolunteer=a.IdVolunteer
 return @AllHourMonth-@Hour
 end
 print dbo.CountHourMonth('000000001')
 --2 צרי פרוצדורה שתקבל קוד שירות ותשלוף את המתנדבים שנותרו לו הכי 
--הרבה שעות לתרום החודש בשירות זה.
create function TmpCountHourMonth(@idVolunteer NCHAR(9),@idService int)
 returns int
 as begin
 declare @AllHourMonth int
 set @AllHourMonth=0
 declare @Hour int
 set @Hour=0
 select @AllHourMonth= SUM(MonthlyHours) from VolunteerServices
 where @idVolunteer=IdVolunteer and @idService=IdService
 select  @Hour= SUM(RequestedHours) 
 from Requests r join Assignments a 
 on(a.IdRequest=r.IdRequest)
 where @idVolunteer=a.IdVolunteer and @idService=IdService
 and datediff(month, getdate(),RequestDate)=0

 return @AllHourMonth-@Hour
 end
 select dbo.TmpCountHourMonth('000000001',100000001)   
create procedure GetVolunteerMaxCountHourMonth(@idService int)
as begin
select v.IdVolunteer, v.Name ,v.Phone 
from VolunteerServices vs join Volunteers v 
on (v.IdVolunteer=vs.IdVolunteer)
where 100000001= IdService AND dbo.TmpCountHourMonth(v.IdVolunteer,@idService) >= ALL (
                                                                            SELECT dbo.TmpCountHourMonth(IdVolunteer,IdService)
                                                                             FROM  VolunteerServices
                                                                             where idservice=@idService)
                                                                            
group by v.IdVolunteer, v.Name ,v.Phone
end
drop procedure GetVolunteerMaxCountHourMonth
exec GetVolunteerMaxCountHourMonth 100000001
--3 צרי פרוצדורה שתקבל קוד שירות ותחזיר כמה מתנדבים יש בשירת זה וכמה
--בקשות אושרו בשירות זה השנה.
create procedure CountVolunteerAndRequestsYearInService(@idService int, @countV int output ,@countR int output)
as begin
select @countV=count(*) from VolunteerServices
where @idService=IdService
select @countR=count(*) from Requests r join Assignments a on(r.IdRequest=a.IdRequest)
where @idService=r.IdService and YEAR(r.RequestDate)=YEAR(GETDATE()) 
end
declare @cv int, @cR int
exec CountVolunteerAndRequestsYearInService 100000001 , @cv output ,@cR output
PRINT @cv
PRINT @cR
--מקבלת קוד מתנדב ומחזירה כמה שעות תרם החודש וממוצע השעות שתרם חודש שעבר
create procedure CountHoursAndAvgHourLastYear( @VolunteerId NCHAR(9),  @HoursThisMonth int output ,@AverageHoursPerMonth float  output)
as begin
select @HoursThisMonth=sum(RequestedHours) from Requests r join Assignments a on(a.IdRequest=r.IdRequest)
where @VolunteerId=a.IdVolunteer and  MONTH(r.RequestDate) = MONTH(GETDATE())
      and YEAR(r.RequestDate) = YEAR(GETDATE())
select @AverageHoursPerMonth=avg(RequestedHours) from Requests r join Assignments a on(a.IdRequest=r.IdRequest)
where @VolunteerId=a.IdVolunteer and datediff(month,RequestDate,getdate())=1
end

drop PROCEDURE CountHoursAndAvgHourLastYear
declare @ch int
declare @avg float 
exec CountHoursAndAvgHourLastYear '000000001' , @ch output ,@avg output
PRINT @ch
PRINT @avg
-- פרוזדורה המקבלת קוד מתנדב ושולפת שם נכה, פלאפון , כתובות, שם שירות , תוכן הבקשה, תאריך עבור כל הבקשות הקרובות שלו ממויין לפי תאריך

create procedure GetUpcomingRequestsForVolunteer (@VolunteerId NCHAR(9) )
as begin
select  c.Name,c.Phone,c.Address,s.ServiceName,r.RequestText,r.RequestDate
from Requests r JOIN Assignments a on (a.IdRequest = r.IdRequest)
join CarHelpRequesters c on( r.IdRequester = c.IdRequester) 
join Services s on(s.IdService=r.IdService)
where a.IdVolunteer = @VolunteerId
and r.RequestDate >= GETDATE()
order by r.RequestDate
end
drop procedure GetUpcomingRequestsForVolunteer
EXEC GetUpcomingRequestsForVolunteer '000000001'
--4 צרי פונקצייה שתקבל קוד שירות ותחזיר האם יש מספיק שעות שנתרמו-
--האם מספר השעות שנתרמו בחודש גדול מהממוצע שעות שמבקשים 
--בחודש.
create function IsServiceHoursSufficientThisMonth(@idService int)
 returns bit
 as begin
 declare @AllHourMonth int
 declare @AllHourRequests int
 select @AllHourMonth=SUM(MonthlyHours) from VolunteerServices
 where @idService=IdService
 select @AllHourRequests=AVG(RequestedHours) from Requests
 where @idService=IdService
 if(@AllHourMonth>@AllHourRequests)
 return 1
 return 0
 end
-- 5 צרי פונקצייה שתקבל קוד מתנדב ותחזיר כמה שירותים הוא נותן- ואין עוד 
--שנותנים כזה שירות
create function Count_Unique_Services_By_Volunteer(@VolunteerId NCHAR(9))
returns int
as begin 
declare @Count int;
select @Count = COUNT(*) from VolunteerServices vs
where vs.IdVolunteer = @VolunteerId
and (select COUNT(*) from VolunteerServices vs2 
     where vs2.IdService = vs.IdService) = 1;
return @Count;
end

