

using InternalResourceBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InternalResourceBookingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Resource> Resources { get; set; }
        public DbSet<Models.Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DB Relationships
            modelBuilder.Entity<Booking>()
            .HasOne(b => b.Resource)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.ResourceId)
            .OnDelete(DeleteBehavior.SetNull);


            //Prepopulate Resources
            modelBuilder.Entity<Resource>().HasData(
                // Meeting Rooms
                new Resource { Id = 1, Name = "Meeting Room Alpha", Description = "10-seater with projector & whiteboard", Location = "2nd Floor, West Wing", Capacity = 10, IsAvailable = true },
                new Resource { Id = 2, Name = "Meeting Room Beta", Description = "8-seater with video conferencing", Location = "3rd Floor, East Wing", Capacity = 8, IsAvailable = true },
                new Resource { Id = 3, Name = "Boardroom Executive", Description = "Premium boardroom for 16 people", Location = "1st Floor, Admin Block", Capacity = 16, IsAvailable = true },
                new Resource { Id = 4, Name = "Huddle Room 1", Description = "Quick 4-person collaboration space", Location = "4th Floor, Open Area", Capacity = 4, IsAvailable = true },
                new Resource { Id = 5, Name = "Training Room", Description = "30-seater training facility", Location = "Ground Floor, Training", Capacity = 30, IsAvailable = false }, // under maintenance

                // Company Vehicles
                new Resource { Id = 6, Name = "Toyota Corolla (Car 1)", Description = "Compact sedan - White", Location = "Parking Bay A1", Capacity = 4, IsAvailable = true },
                new Resource { Id = 7, Name = "Ford Ranger (Bakkie)", Description = "Double cab for site visits", Location = "Parking Bay B3", Capacity = 5, IsAvailable = true },
                new Resource { Id = 8, Name = "Mercedes Sprinter Van", Description = "15-seater passenger van", Location = "Garage Level 2", Capacity = 15, IsAvailable = false }, // in service
                new Resource { Id = 9, Name = "Nissan NP200 (Delivery)", Description = "Small delivery bakkie", Location = "Loading Bay", Capacity = 2, IsAvailable = true },

                // IT & AV Equipment
                new Resource { Id = 10, Name = "Dell Laptop Pro", Description = "i7, 32GB RAM, 1TB SSD", Location = "IT Storage Room", Capacity = 1, IsAvailable = true },
                new Resource { Id = 11, Name = "MacBook Pro 16", Description = "M2 Max for design/video", Location = "Creative Team Locker", Capacity = 1, IsAvailable = false },
                new Resource { Id = 12, Name = "Projector Epson 4K", Description = "Portable 4K projector", Location = "AV Cupboard", Capacity = 1, IsAvailable = true },
                new Resource { Id = 13, Name = "JBL Party Speakers", Description = "Portable Bluetooth speakers", Location = "Events Store", Capacity = 1, IsAvailable = true },
                new Resource { Id = 14, Name = "Wireless Mic Set (4)", Description = "Wireless microphone kit", Location = "AV Cupboard", Capacity = 4, IsAvailable = true },

                // Office Utilities
                new Resource { Id = 15, Name = "Large Color Printer", Description = "HP Color LaserJet - A3 capable", Location = "Print Room, 2nd Floor", Capacity = 1, IsAvailable = true },
                new Resource { Id = 16, Name = "Standing Desk", Description = "Electric height-adjustable desk", Location = "Furniture Storage", Capacity = 1, IsAvailable = true },
                new Resource { Id = 17, Name = "4G Mobile Hotspot", Description = "Portable Unlimited data router", Location = "IT Desk", Capacity = 1, IsAvailable = false },

                // Fun / Wellness
                new Resource { Id = 18, Name = "Xbox Series X + TV", Description = "Gaming setup in chill room", Location = "Recreation Room, 5th Floor", Capacity = 6, IsAvailable = true },
                new Resource { Id = 19, Name = "Massage Chair", Description = "Full-body massage chair", Location = "Wellness Room", Capacity = 1, IsAvailable = true },
                new Resource { Id = 20, Name = "Coffee Machine (Barista)", Description = "Professional espresso machine", Location = "Kitchen, 4th Floor", Capacity = 1, IsAvailable = true }
            );


            //Prepopulate Bookings
            modelBuilder.Entity<Booking>().HasData(
                // Past Bookings
                new Booking { Id = 1, ResourceId = 1, StartTime = new DateTime(2025, 11, 20, 09, 00, 00), EndTime = new DateTime(2025, 11, 20, 11, 00, 00), BookedBy = "Thandi Mokoena", Purpose = "Sprint Planning" },
                new Booking { Id = 2, ResourceId = 6, StartTime = new DateTime(2025, 11, 25, 08, 00, 00), EndTime = new DateTime(2025, 11, 25, 17, 00, 00), BookedBy = "Sipho Ngubane", Purpose = "Client Visit - Cape Town" },
                new Booking { Id = 3, ResourceId = 10, StartTime = new DateTime(2025, 11, 18, 09, 00, 00), EndTime = new DateTime(2025, 11, 21, 17, 00, 00), BookedBy = "Lerato Khumalo", Purpose = "Offsite Development Sprint" },

                // Recent / This Week
                new Booking { Id = 4, ResourceId = 3, StartTime = new DateTime(2025, 12, 03, 10, 00, 00), EndTime = new DateTime(2025, 12, 03, 12, 00, 00), BookedBy = "Lisa Naidoo", Purpose = "Executive Leadership Meeting" },
                new Booking { Id = 5, ResourceId = 1, StartTime = new DateTime(2025, 12, 03, 14, 00, 00), EndTime = new DateTime(2025, 12, 03, 16, 00, 00), BookedBy = "Dev Team", Purpose = "Product Demo Rehearsal" },
                new Booking { Id = 6, ResourceId = 12, StartTime = new DateTime(2025, 12, 04, 09, 00, 00), EndTime = new DateTime(2025, 12, 04, 12, 00, 00), BookedBy = "Events Team", Purpose = "Year-End Townhall Setup" },
                new Booking { Id = 7, ResourceId = 18, StartTime = new DateTime(2025, 12, 05, 17, 00, 00), EndTime = new DateTime(2025, 12, 05, 19, 30, 00), BookedBy = "HR Department", Purpose = "Team Building Gaming Night" },

                new Booking { Id = 8, ResourceId = 2, StartTime = new DateTime(2025, 12, 05, 10, 00, 00), EndTime = new DateTime(2025, 12, 05, 12, 00, 00), BookedBy = "Finance Team", Purpose = "2026 Budget Review" },
                new Booking { Id = 9, ResourceId = 7, StartTime = new DateTime(2025, 12, 04, 07, 30, 00), EndTime = new DateTime(2025, 12, 04, 18, 00, 00), BookedBy = "Field Operations", Purpose = "Site Visit - Durban" },
                new Booking { Id = 10, ResourceId = 4, StartTime = new DateTime(2025, 12, 06, 13, 00, 00), EndTime = new DateTime(2025, 12, 06, 14, 00, 00), BookedBy = "Design Team", Purpose = "Quick Brainstorm" },
                
                // Upcoming Bookings
                new Booking { Id = 11, ResourceId = 10, StartTime = new DateTime(2025, 12, 15, 09, 00, 00), EndTime = new DateTime(2025, 12, 19, 17, 00, 00), BookedBy = "Nomsa Zuma", Purpose = "Training Workshop Prep" },
                new Booking { Id = 12, ResourceId = 13, StartTime = new DateTime(2025, 12, 20, 14, 00, 00), EndTime = new DateTime(2025, 12, 20, 19, 00, 00), BookedBy = "Marketing Team", Purpose = "Product Launch Party" },
                new Booking { Id = 13, ResourceId = 19, StartTime = new DateTime(2025, 12, 09, 12, 00, 00), EndTime = new DateTime(2025, 12, 09, 12, 30, 00), BookedBy = "Wellness Committee", Purpose = "Stress Relief Session" },
                new Booking { Id = 14, ResourceId = 20, StartTime = new DateTime(2025, 12, 11, 08, 00, 00), EndTime = new DateTime(2025, 12, 11, 10, 00, 00), BookedBy = "Early Risers Club", Purpose = "Coffee Tasting Morning" },

                new Booking { Id = 15, ResourceId = 1, StartTime = new DateTime(2025, 12, 18, 09, 00, 00), EndTime = new DateTime(2025, 12, 18, 11, 00, 00), BookedBy = "Sales Team", Purpose = "Q4 Sales Planning" },
                new Booking { Id = 16, ResourceId = 3, StartTime = new DateTime(2025, 12, 18, 10, 30, 00), EndTime = new DateTime(2025, 12, 18, 12, 30, 00), BookedBy = "HR Team", Purpose = "Performance Reviews" }, 

                // More Future Bookings
                new Booking { Id = 17, ResourceId = 6, StartTime = new DateTime(2025, 12, 23, 13, 00, 00), EndTime = new DateTime(2025, 12, 23, 17, 00, 00), BookedBy = "Logistics", Purpose = "Year-End Deliveries" },
                new Booking { Id = 18, ResourceId = 15, StartTime = new DateTime(2025, 12, 16, 09, 00, 00), EndTime = new DateTime(2025, 12, 16, 17, 00, 00), BookedBy = "Finance", Purpose = "Annual Report Printing" },
                new Booking { Id = 19, ResourceId = 11, StartTime = new DateTime(2026, 01, 06, 09, 00, 00), EndTime = new DateTime(2026, 01, 10, 17, 00, 00), BookedBy = "Creative Director", Purpose = "Brand Video Project" },
                new Booking { Id = 20, ResourceId = 3, StartTime = new DateTime(2025, 12, 19, 14, 00, 00), EndTime = new DateTime(2025, 12, 19, 17, 00, 00), BookedBy = "Board of Directors", Purpose = "Year-End Board Meeting" }
            );
        }

    }
}
