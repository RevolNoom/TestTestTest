EXEC dropTables;
EXEC generateTables;

-- Ex1: Insert du lieu test 
EXEC generateData;

SELECT 'Ex2: Sinh vien co ma SV0001';
SELECT * from StudentMng WHERE code = 'SV0001';
SELECT '';

SELECT 'Ex3: Diem vat ly < 4';
SELECT * from StudentMng WHERE phys < 4;
SELECT '';

SELECT 'Ex4: Diem Vat ly va Toan < 5';
SELECT * from StudentMng WHERE phys < 5 AND math < 5;
SELECT '';

SELECT 'Ex5: Update tat ca diem toan them 1';
--SELECT 'Truoc:';
--SELECT code, math from StudentMng ORDER BY student_id;
UPDATE StudentMng SET math = (math + 1) % 11;
--SELECT 'Sau:';
--SELECT code, math from StudentMng ORDER BY student_id;
SELECT '';

SELECT 'Ex6: Update diem vat ly them 1 neu <4';
--SELECT 'Truoc:';
--SELECT code, phys from StudentMng ORDER BY student_id;
UPDATE StudentMng SET phys = phys + 1 WHERE phys < 4;
--SELECT 'Sau:';
--SELECT code, phys from StudentMng ORDER BY student_id;
SELECT '';


SELECT 'Ex7: Update ca hai diem them 1 neu ca hai <5';
UPDATE StudentMng SET phys = phys + 1, math = math + 1 WHERE phys < 5 AND math < 5;
SELECT '';

-- Ex8: Xoa sinh vien SV0001
DELETE FROM StudentMng WHERE code = 'SV0001';


SELECT COUNT(student_id) as 'Ex4.1: So sinh vien vat ly < 4' FROM StudentMng WHERE phys < 4;

SELECT COUNT(student_id) as 'Ex4.2: So sinh vien ca hai diem < 5' FROM StudentMng WHERE phys < 5 AND math < 5;

SELECT COUNT(student_id) as 'Ex4.3: So sinh vien tong hai diem < 10' FROM StudentMng WHERE phys + math < 10;

Select '';
Select 'Ex4.4';
SELECT student_id, phys + math as 'Tong 2 diem' FROM StudentMng;

SELECT SUM(math) as 'Ex4.5: Tong diem toan tat ca sinh vien' FROM StudentMng;

SELECT AVG(math) as 'Ex4.6: Trung binh diem Toan tat ca sinh vien' FROM StudentMng;

Select '';
Select 'Ex4.7: 2 sinh vien diem Toan cao nhat';
SELECT TOP 2 student_id, math FROM StudentMng ORDER BY math DESC;


Select '';
Select 'Ex4.8: 2 sinh vien diem Ly thap nhat';
SELECT TOP 2 student_id, phys FROM StudentMng ORDER BY phys ASC;

Select '';
Select 'Ex4.9: 2 sinh vien tong diem cao nhat';
SELECT TOP 2 student_id, phys + math as 'Tong diem' FROM StudentMng ORDER BY phys + math DESC;

Select '';
Select 'Ex5.1: Ten lop & thong tin tung sinh vien';
SELECT c.name, s.*
FROM StudentMng AS s JOIN Class AS c ON c.class_id = s.class_id 
ORDER BY s.class_id, s.student_id ASC;

Select '';
Select 'Ex5.2: So sinh vien theo tung lop';
SELECT c.class_id, COUNT(s.student_id) as 'So sinh vien' 
FROM StudentMng as s JOIN Class as c ON c.class_id = s.class_id GROUP BY c.class_id ORDER BY c.class_id;
