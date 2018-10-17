select * from products
select Id,name from Products
select * from Products
select categoryid,name from Products
select DISTINCT categoryid from Products
select COUNT(distinct categoryid) from Products
select count(*)as distincategoryid from (select distinct categoryid from Products);
select * from Categories
select * from Customers
select * from Customers where Activated='1';
select * from Customers where Password ='123'
--lua chon cac khach hang bat day bang chu s
select * from Customers where Fullname like'a%'
--lua chon cac khach hang ket thuc boi chu a
select * from Customers where Fullname like '%a'
--lua chon cac khach hang co chu a la duoc
select * from Customers where Fullname like'%a%'
--lay tat ca khach hang trong bang 
select * from Customers
--lay tat ca bang product
select * from Products
--lay tat ca ten san pham co categoryid =1000
select  categoryid,id,name,unitprice from products where CategoryId='1000'
--gom tat ca cac field ma co category = nhau vao mot cho bang group by
select categoryid,sum(unitprice) from Products group by CategoryId
--order by trong sql dung de sap xep theo thu tu tang dần hoặc theo thứ tự giảm dần
select * from Products
--lay tat ca bang product ma co id >=1060
select * from Products where id >=1060
--lay tat ca bang product ma co id >=1060 sắp xếp theo thứ tự tăng dần của id
select * from Products where id >=1060 order by id
--lấy tất cả bảng product mà có id >=1060 sắp xếp theo thứ tự tăng dần của id
select * from Products where id >=1060 order by id asc
--lấy tất cả bảng product mà có id >=1060 sắp xếp theo thứ tự giảm dần của id
select * from Products where id >=1060 order by id desc

--từ khóa distinct trong sql được sử dụng kết hợp với select để loại bỏ tất cả các bản sao của bản ghi và chỉ lấy bản ghi duy nhât
select distinct categoryid from Products
--từ khóa as dùng để gán 1 cái tên tạm thời cho côt
select * from Products
select name as 'ten san pham' from products
--menh de  top duoc su dung để lấy dữ liệu của top n hoặc x phần trăm bản ghi 1 bảng
select * from Products
--lay 2 ban ghi dau tiên
select top 2 * from products
--lấy 5% bản ghi đầu tiên
select top 5 percent * from Products
--sử dụn as cho bảng
select id,name from Products as name_id
select id from name_id
--tạo view trong sql
create view  product_view as select id,name from Products
--tạo xong view thì truy vấn như bình thường
select * from product_view
--mệnh đề having trong sql cho bạn khả năng để xác định các điều kiện để lọc nhóm kết quả nào sẽ xuất hiện trong kết quả cuối cùng--
--thứ tự trong sql select =>from =>where=>group by =>having=>order by
--mệnh đề having phải theo sau mệnh đề group by trong 1 truy vấn và cũng phải đặt trước mệnh đề nếu được sử dụng
select * from Products
select id,name,unitprice,categoryid,Supplierid from Products
--sử dụng group by gom các category trùng nhau
select id,name,count(categoryid)from Products group by CategoryId having count(categoryid)>=2