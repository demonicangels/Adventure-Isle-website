CREATE PROCEDURE [dbo].[DestinationProc]
	@country VARCHAR(100),
	@avgRating DECIMAL, 
	@history VARCHAR(200),
	@name VARCHAR(100) NOT NULL
	AS
    if @name is null
    BEGIN
      RAISERROR (15600,-1,-1,'myProcedure'); 
	END
	BEGIN
	SELECT * 
	FROM Destinations 
	WHERE Country = @country AND  Name = @name AND AvgRating = @avgRating AND History = @history 
	END 
