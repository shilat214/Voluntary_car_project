-- Volunteers
insert into Volunteers values
('000000001', 'John Smith', '0500000001'),
('000000002', 'Sarah Lee', '0500000002'),
('000000003', 'Mike Brown', '0500000003'),
('000000004', 'Anna White', '0500000004'),
('000000005', 'David Green', '0500000005'),
('000000006', 'Laura Black', '0500000006'),
('000000007', 'Robert Gray', '0500000007'),
('000000008', 'Emma Stone', '0500000008'),
('000000009', 'Tom King', '0500000009'),
('000000010', 'Olivia Hill', '0500000010');

-- Services
insert into Services values
('100000001', 'Wheelchair Transport'),
('100000002', 'Hospital Transport'),
('100000003', 'Home Visits'),
('100000004', 'Medical Deliveries'),
('100000005', 'Daily Check-ins'),
('100000006', 'Grocery Delivery'),
('100000007', 'Rehabilitation Rides'),
('100000008', 'Lab Test Transport'),
('100000009', 'Prescription Pickup'),
('100000010', 'Emergency Help');

-- VolunteerServices
insert into VolunteerServices (IdVolunteer, IdService, MonthlyHours) values
('000000001', '100000001', 10),
('000000002', '100000002', 8),
('000000003', '100000003', 12),
('000000004', '100000004', 15),
('000000005', '100000005', 7),
('000000006', '100000006', 10),
('000000007', '100000007', 6),
('000000008', '100000008', 9),
('000000009', '100000009', 11),
('000000010', '100000010', 13);

-- CarHelpRequesters
insert into CarHelpRequesters values
('200000001', 'Alice Moon', '0510000001', '1 First St'),
('200000002', 'Brian Fox', '0510000002', '2 Second St'),
('200000003', 'Clara Doe', '0510000003', '3 Third St'),
('200000004', 'Daniel Roy', '0510000004', '4 Fourth St'),
('200000005', 'Eva Sky', '0510000005', '5 Fifth St'),
('200000006', 'Frank Sun', '0510000006', '6 Sixth St'),
('200000007', 'Grace Kim', '0510000007', '7 Seventh St'),
('200000008', 'Henry Joe', '0510000008', '8 Eighth St'),
('200000009', 'Ivy May', '0510000009', '9 Ninth St'),
('200000010', 'Jack Ray', '0510000010', '10 Tenth St');

-- Requests
insert into Requests (IdRequester, IdService, IdVolunteer, RequestText, RequestStatus, RequestDate, RequestedHours) values
('200000001', '100000001', '000000001', 'Car for rent on a voluntary basis', 'Approved', '2024-01-10', 3),
('200000002', '100000002', '000000002', 'Car for rent on a voluntary basis', 'Pending', '2024-01-15', 2),
('200000003', '100000003', '000000003', 'Car for rent on a voluntary basis', 'Approved', '2024-02-01', 4),
('200000004', '100000004', '000000004', 'Car for rent on a voluntary basis', 'Approved', '2024-02-05', 5),
('200000005', '100000005', '000000005', 'Car for rent on a voluntary basis', 'Pending', '2024-02-20', 3),
('200000006', '100000006', '000000006', 'Car for rent on a voluntary basis', 'Approved', '2024-03-01', 2),
('200000007', '100000007', '000000007', 'Car for rent on a voluntary basis', 'Pending', '2024-03-15', 1),
('200000008', '100000008', '000000008', 'Car for rent on a voluntary basis', 'Approved', '2024-03-25', 6),
('200000009', '100000009', '000000009', 'Car for rent on a voluntary basis', 'Approved', '2024-04-01', 2),
('200000010', '100000010', '000000010', 'Car for rent on a voluntary basis', 'Pending', '2024-04-10', 4);


-- Assignments
insert into Assignments (IdRequest, IdVolunteer) values
(1, '000000001'),
(3, '000000003'),
(4, '000000004'),
(6, '000000006'),
(8, '000000008'),
(9, '000000009');
