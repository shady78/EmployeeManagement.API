-- Query to find the top 3 highest-paid employees in each department.

WITH RankedEmployees AS (
    SELECT 
        EmployeeID,
        Name,
        Department,
        Salary,
        ROW_NUMBER() OVER (PARTITION BY Department ORDER BY Salary DESC) AS Rank
    FROM Employees
)
SELECT 
    EmployeeID,
    Name,
    Department,
    Salary
FROM RankedEmployees
WHERE Rank <= 3
ORDER BY Department, Rank;


-- The query uses a Common Table Expression (CTE) to rank employees by salary within each department.
-- It then selects the top 3 employees from each department based on their salaries.
