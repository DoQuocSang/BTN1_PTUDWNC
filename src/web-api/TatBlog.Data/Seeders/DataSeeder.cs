using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
    // Tạo Migration
    // Add-Migration InitialCreate
    // Cập nhật Database
    // Update-Database -Verbose


    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;

        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Posts.Any()) return;

            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);
            var books = AddBooks(authors, categories);
            //var carts = AddCarts();
        }

        private IList<Author> AddAuthors() 
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName = "Nguyễn Nhật Ánh",
                    UrlSlug = "nguyen-nhat-anh",
                    Email = "nguyen-nhat-anh.com",
                    JoinedDate = new DateTime(2020, 4, 21),
                    Notes = "Nguyễn Nhật Ánh là một nhà văn, nhà thơ, bình luận viên Việt Nam." +
                    "Ông được biết đến qua nhiều tác phẩm văn học về đề tài tuổi trẻ, các tác phẩm của ông " +
                    "rất được độc giả ưa chuộng và nhiều tác phẩm đã được chuyển thể thành phim"
                },
                new()
                {
                    FullName = "Đoàn Giỏi",
                    UrlSlug = "doan-gioi",
                    Email = "doan-gioi.com",
                    JoinedDate = new DateTime(2020, 4, 19),
                    Notes ="Đoàn Giỏi (17 tháng 5 năm 1925 – 2 tháng 4 năm 1989), là một nhà văn Việt Nam, " +
                    "hội viên Hội Nhà văn Việt Nam từ năm 1957. Ông có những bút danh khác như: Nguyễn Hoài, Nguyễn Phú Lễ, Huyền Tư"
                },
                new()
                {
                    FullName = "Dale Carnegie",
                    UrlSlug = "dale-carnegie",
                    Email = "dale-carnegie.com",
                    JoinedDate = new DateTime(2019, 5, 1),
                    Notes ="Dale Breckenridge Carnegie là một nhà văn và nhà thuyết trình Mỹ " +
                    "và là người phát triển các lớp tự giáo dục, nghệ thuật bán hàng, huấn luyện đoàn thể, " +
                    "nói trước công chúng và các kỹ năng giao tiếp giữa mọi người"
                },
                new()
                {
                    FullName = "Paulo Coelho",
                    UrlSlug = "paulo-coelho",
                    Email = "paulo-coelho.com",
                    JoinedDate = new DateTime(2020, 12, 10),
                    Notes = "Paulo Coelho (sinh ngày 24 tháng 8 năm 1947) là tiểu thuyết gia nổi tiếng người Brasil"
                },
                new()
                {
                    FullName = "Nick Vujicic",
                    UrlSlug = "nick-vujicic",
                    Email = "nick-vujicic.com",
                    JoinedDate = new DateTime(2020, 5, 30),
                    Notes = "Nicholas James \"Nick\" Vujicic là một người truyền bá Phúc Âm và diễn giả truyền cảm hứng người Úc gốc Serbia, " +
                    "khi được sinh ra đã không có tứ chi mà chỉ có 1 bàn chân và 2 ngón chân nhỏ"
                },
                 new()
                {
                    FullName = "Bill Gates",
                    UrlSlug = "bill-gates",
                    Email = "bill-gates.com",
                    JoinedDate = new DateTime(2020, 5, 30),
                    Notes = "William Henry Bill Gates III (sinh ngày 28 tháng 10 năm 1955) là một doanh nhân người Mỹ, nhà từ thiện, tác giả" +
                    " và chủ tịch tập đoàn Microsoft, hãng phần mềm mà ông cùng với Paul Allen đã sáng lập ra. Ông luôn có mặt trong danh sách " +
                    "những người giàu nhất trên thế giới."
                },
                new()
                {
                    FullName = "Robert Toru Kiyosaki",
                    UrlSlug = "robert-toru-kiyosaki",
                    Email = "robert-toru-kiyosaki.com",
                    JoinedDate = new DateTime(2020, 7, 7),
                    Notes = "Robert Toru Kiyosaki (sinh ngày 8 tháng 4 năm 1947) là một nhà đầu tư, doanh nhân đồng thời là một tác giả người Mỹ." +
                    "Kiyosaki nổi tiếng bởi cuốn sách Rich Dad, Poor Dad (Cha Giàu, Cha Nghèo). Ông đã viết 18 cuốn sách, bán tổng cộng 26 triệu bản."
                },
                new()
                {
                    FullName = "Haro Aso",
                    UrlSlug = "haro-aso",
                    Email = "haroaso@gmail.com",
                    JoinedDate = new DateTime(2020, 7, 7),
                    Notes = "Haro Aso"
                }
           
            };

            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        } 

        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new(){Name = "Chính trị – pháp luật", Description = "Là thể loại sách nói về pháp luật", UrlSlug = "chinhtri-phapluat", ShowOnMenu = true},
                new(){Name = "Kinh tế", Description = "Là thể loại sách nói về kinh tế", UrlSlug = "kinhte", ShowOnMenu = true},
                new(){Name = "Văn học nghệ thuật", Description = "Là thể loại văn học nghệ thuật", UrlSlug = "vanhocnghethuat", ShowOnMenu = true},
                new(){Name = "Tiểu thuyết", Description = "Là một thể loại văn xuôi có hư cấu", UrlSlug = "tieuthuyet", ShowOnMenu = true},
                new(){Name = "Tâm lý, tâm linh, tôn giáo", Description = "Là thể loại nói về các bí ẩn về tâm linh, tôn giáo", UrlSlug = "tamly-tamlinh-tongiao", ShowOnMenu = true},
                
                new(){Name = "Sách tự lực", Description = "Là sách được viết với mục đích hướng dẫn độc giả giải quyết những vấn đề cá nhân. Dòng sách lấy tên từ Self-Help, " +
                 "cuốn sách bán chạy nhất năm 1859 của Samuel Smiles, nhưng còn được biết đến và phân loại theo \"tự cải thiện\", một thuật ngữ bản hiện đại hóa của tự lực", UrlSlug = "sach-tu-luc", ShowOnMenu = true},
                new(){Name = "Thiếu nhiThiếu nhi", Description = "Là những loại sách dành cho thiếu nhi", UrlSlug = "thieunhi", ShowOnMenu = true},
                new(){Name = "Truyện ngắn", Description = "Là thể loại truyện ngắn về một câu chuyện nào đó", UrlSlug = "truyenngan", ShowOnMenu = true},
                new(){Name = "Truyện tranh", Description = "Là thể loại về truyện tranh", UrlSlug = "truyentranh", ShowOnMenu = true},
                new(){Name = "Giáo trình", Description = "Là thể loại sách , tài liệu cụ thể, nói về các lĩnh vực nghiên cứu", UrlSlug = "giaotrinhgiaotrinh", ShowOnMenu = true},
                
                new(){Name = "Khoa học viễn tưởng", Description = "Là thể loại sách nói vể khoa học, nói về một vấn đề mà không có thật ở hiện tại", UrlSlug = "khoahocvientuong", ShowOnMenu = true},
            };

            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;
        }

        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new(){Name = "Chính trị – pháp luật", Description = "Là thể loại sách nói về pháp luật", UrlSlug = "chinhtri-phapluat"},
                new(){Name = "Kinh tế", Description = "Là thể loại sách nói về kinh tế", UrlSlug = "kinhte"},
                new(){Name = "Văn học nghệ thuật", Description = "Là thể loại văn học nghệ thuật", UrlSlug = "vanhocnghethuat"},
                new(){Name = "Tiểu thuyết", Description = "tieuthuyet", UrlSlug = "Là một thể loại văn xuôi có hư cấu"},
                new(){Name = "Tâm lý, tâm linh, tôn giáo", Description = "Là thể loại nói về các bí ẩn về tâm linh, tôn giáo", UrlSlug = "tamly-tamlinh-tongiao"},

                new(){Name = "Thiếu nhiThiếu nhi", Description = "Là những loại sách dành cho thiếu nhi,", UrlSlug = "thieunhi"},
                new(){Name = "Truyện ngắn", Description = "Là thể loại truyện ngắn về một câu chuyện nào đó", UrlSlug = "truyenngan"},
                new(){Name = "Giáo trình", Description = "Là thể loại sách , tài liệu cụ thể, nói về các lĩnh vực nghiên cứu", UrlSlug = "giaotrinh"},
                new(){Name = "Khoa học viễn tưởng ", Description = "Là thể loại sách nói vể khoa học, nói về một vấn đề mà không có thật ở hiện tại", UrlSlug = "khoahocvientuong"},
                new(){Name = "Truyện tranh", Description = "Là thể loại về truyện tranh", UrlSlug = "truyentranh"},
            };

            _dbContext.Tags.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }

        private IList<Post> AddPosts(
            IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags
            )
        {
            var posts = new List<Post>()
            {
                new()
                {
                    Title = "Tôi thấy hoa vàng trên cỏ xanh",
                    ShortDescription = "Là một tiểu thuyết dành cho thanh thiếu niên của nhà văn Nguyễn Nhật Ánh, xuất bản lần đầu tại Việt Nam " +
                    "vào ngày 9 tháng 12 năm 2010 bởi Nhà xuất bản Trẻ với phần tranh minh họa do Đỗ Hoàng Tường thực hiện.",
                    Description = "Câu chuyện là những trang nhật ký về cuộc sống thường ngày và tâm tư của cậu bé Thiều. Thiều đang là học sinh lớp 7 sống ở một vùng quê nghèo, cùng với người em trai tên Tường. Tường là một cậu bé dễ thương, hiền lành, bao dung, rất yêu mến anh trai và thích chơi đùa với nhiều loài động vật gồm cả sâu bọ, rắn rết." +
                    " Cậu bé sống nội tâm, ham đọc sách và rất say mê những câu chuyện cổ tích, đặc biệt là truyện Cóc tía, chính vì vậy mà cậu nuôi nấng một con cóc dưới gầm giường và đặt tên cho nó là \"Cu Cậu”.",
                    Meta = "Toi thay hoa vang tren co xanh",
                    UrlSlug = "toi-thay-hoa-vang-tren-co-xanh",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 1860,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[3]
                    }
                },

                new()
                {
                    Title = "Mắt biếc",
                    ShortDescription = "Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)…Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người)." +
                    " Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).",
                    Description = "Mắt biếc xoay quanh mối tình đơn phương của Ngạn với Hà Lan, cô bạn gái có cặp mắt hút hồn nhưng cá tính bướng bỉnh. Một chuyện tình nhiều cung bậc, từ ngộ nghĩnh trẻ con, rồi tình yêu thuở học trò trong sáng, trải qua bao biến cố, trở thành một cuộc \"đuổi hình bắt bóng\" buồn da diết nhưng không nguôi hi vọng. " +
                    "Câu chuyện càng trở nên éo le hơn khi Trà Long - con gái của Hà Lan lớn lên lại nhen nhóm một tình yêu như thế với Ngạn.",
                    Meta = "Mat biec",
                    UrlSlug = "mat-biec",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                    Title = "Đất rừng Phương Nam",
                    ShortDescription = " Là truyện được biết đến nhiều nhất của ông. Đây được xem là bài ca tuyệt vời về thiên nhiên và con người Nam Bộ. Cuốn tiểu thuyết kể về cuộc đời phiêu bạt của cậu bé An. " +
                    "Bối cảnh truyện diễn ra ở các tỉnh miền Tây Nam Bộ vào những năm 1945, sau khi thực dân Pháp quay trở lại xâm chiếm vùng đất này..",
                    Description = "Cậu bé An sống cùng với cha mẹ tại thành phố, sau ngày độc lập 2-9-1945. Thực dân Pháp quay trở lại xâm lược Việt Nam, đổ quân vào Nam Bộ. Pháp mở những trận đánh khiến cho những người dân sống tại các thành thị phải di tản." +
                    " An và ba má cũng phải bỏ nhà bỏ cửa để chạy giặc. Cậu nhớ đến một anh bạn đi tàu đã tặng cậu chiếc la bàn mà không kịp mang theo. Theo cha mẹ chạy hết từ vùng này tới vùng khác của miền Tây Nam Bộ. An kết bạn cùng với những đứa trẻ cùng trang lứa và có một cuộc sống tuổi thơ vùng nông thôn đầy êm đềm. " +
                    "Nhưng cứ vừa ổn định được mấy bữa thì giặc đánh tới nơi và lại phải chạy. Trong một lần mải chơi, giặc đánh đến và An đã lạc mất gia đình. Cậu trở thành đứa trẻ lang thang.",
                    Meta = "Dat rung phuong Nam",
                    UrlSlug = "dat-rung-phuong-nam",
                    Published = true,
                    PostedDate = new DateTime(2021, 1, 12, 1, 25, 0),
                    ModifiedDate = null,
                    ViewCount = 1000,
                    Author = authors[1],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                    Title = "Đắc Nhân Tâm",
                    ShortDescription = "Là một quyển sách nhằm tự giúp bản thân (self-help) bán chạy nhất từ trước đến nay. Quyển sách này do Dale Carnegie viết và đã được xuất bản lần đầu vào năm 1936, nó đã được bán 15 triệu bản trên khắp thế giới.[1][2] Nó cũng là quyển sách bán chạy nhất của New York Times trong 10 năm." +
                    " Tác phẩm được đánh giá là cuốn sách đầu tiên và hay nhất trong thể loại này, có ảnh hưởng thay đổi cuộc đời đối với hàng triệu người trên thế giới.",
                    Description = "Quyển sách đưa ra các lời khuyên về cách thức cư xử, ứng xử và giao tiếp với mọi người để đạt được thành công trong cuộc sống (theo bản dịch của dịch giả Nguyễn Hiến Lê). Quyển sách gồm 6 phần, mỗi phần có nhiều chương.",
                    Meta = "Dac nhan tam",
                    UrlSlug = "dac-nhan-tam",
                    Published = true,
                    PostedDate = new DateTime(2020, 1, 3, 5, 23, 0),
                    ModifiedDate = null,
                    ViewCount = 569,
                    Author = authors[2],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                    Title = "Quẳng Gánh Lo Đi Và Vui Sống",
                    ShortDescription = "Là một sách tự lực của tác giả người Mỹ Dale Carnegie, được viết vào năm 1948. Bản Việt Ngữ do Nguyễn Hiến Lê dịch năm 1955 tại Sài Gòn và đưa vào tủ sách Học làm người. " +
                    "Quyển sách này là một cẩm nang về cách làm việc và vui sống không bị lo âu.",
                    Description = "Phương cách để trị ưu phiền\r\nCách phân tích những vấn đề rắc rối[\r\nDiệt tất ưu phiền đi, đừng để nó diệt ta\r\n.",
                    Meta = "Quang ganh lo di va vui song.",
                    UrlSlug = "quang-ganh-lo-di-va-vui-song",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 1, 7, 2, 0),
                    ModifiedDate = null,
                    ViewCount = 560,
                    Author = authors[2],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[7]
                    }
                },

                //================================================5

                new()
                {
                    Title = "Tham Vọng Lớn Lao Và Quá Trình Hình Thành Đế Chế Microsoft",
                    ShortDescription = "Tham Vọng Lớn Lao Và Quá Trình Hình Thành Đế Chế Microsoft (Tái Bản 2022). Trong tiết lộ thú vị này, " +
                    "hai phóng viên điều tra Wallace và Erickson đã lần theo bước chân của Gates từ những ngày còn là một hac. Một phần doanh nhân, một phần lập dị, Gates đã trở thành nhân vật quyền.",
                    Description = "Cuốn sách này mở ra một câu chuyện sinh động và chân thực nhất về sự nổi lên của một thiên tài độc đoán, cách thức ông làm thay đổi cả một nền công nghiệp máy tính, và lý do tại sao mọi người quyết tâm tìm hiểu ông bằng được.",
                    Meta = "Tham vong lon lao va qua trinh hinh thanh de che microsoft",
                    UrlSlug = "tham-vong-lon-lao-va-qua-trinh-hinh-thanh-de-che-microsoft",
                    Published = true,
                    PostedDate = new DateTime(2020, 3, 30, 10, 45, 0),
                    ModifiedDate = null,
                    ViewCount = 800,
                    Author = authors[5],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                      Title = "Mắt biếc",
                    ShortDescription = "Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)…Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người)." +
                    " Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).",
                    Description = "Mắt biếc xoay quanh mối tình đơn phương của Ngạn với Hà Lan, cô bạn gái có cặp mắt hút hồn nhưng cá tính bướng bỉnh. Một chuyện tình nhiều cung bậc, từ ngộ nghĩnh trẻ con, rồi tình yêu thuở học trò trong sáng, trải qua bao biến cố, trở thành một cuộc \"đuổi hình bắt bóng\" buồn da diết nhưng không nguôi hi vọng. " +
                    "Câu chuyện càng trở nên éo le hơn khi Trà Long - con gái của Hà Lan lớn lên lại nhen nhóm một tình yêu như thế với Ngạn.",
                    Meta = "Mat biec",
                    UrlSlug = "mat-biec",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {   Title = "Mắt biếc",
                    ShortDescription = "Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)…Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người)." +
                    " Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).",
                    Description = "Mắt biếc xoay quanh mối tình đơn phương của Ngạn với Hà Lan, cô bạn gái có cặp mắt hút hồn nhưng cá tính bướng bỉnh. Một chuyện tình nhiều cung bậc, từ ngộ nghĩnh trẻ con, rồi tình yêu thuở học trò trong sáng, trải qua bao biến cố, trở thành một cuộc \"đuổi hình bắt bóng\" buồn da diết nhưng không nguôi hi vọng. " +
                    "Câu chuyện càng trở nên éo le hơn khi Trà Long - con gái của Hà Lan lớn lên lại nhen nhóm một tình yêu như thế với Ngạn.",
                    Meta = "Mat biec",
                    UrlSlug = "mat-biec",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                      Title = "Mắt biếc",
                    ShortDescription = "Một tác phẩm được nhiều người bình chọn là hay nhất của nhà văn này. Một tác phẩm đang được dịch và giới thiệu tại Nhật Bản (theo thông tin từ các báo)…Bởi sự trong sáng của một tình cảm, bởi cái kết thúc rất, rất buồn khi suốt câu chuyện vẫn là những điều vui, buồn lẫn lộn (cái kết thúc không như mong đợi của mọi người)." +
                    " Cũng bởi, mắt biếc… năm xưa nay đâu (theo lời một bài hát).",
                    Description = "Mắt biếc xoay quanh mối tình đơn phương của Ngạn với Hà Lan, cô bạn gái có cặp mắt hút hồn nhưng cá tính bướng bỉnh. Một chuyện tình nhiều cung bậc, từ ngộ nghĩnh trẻ con, rồi tình yêu thuở học trò trong sáng, trải qua bao biến cố, trở thành một cuộc \"đuổi hình bắt bóng\" buồn da diết nhưng không nguôi hi vọng. " +
                    "Câu chuyện càng trở nên éo le hơn khi Trà Long - con gái của Hà Lan lớn lên lại nhen nhóm một tình yêu như thế với Ngạn.",
                    Meta = "Mat biec",
                    UrlSlug = "mat-biec",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[0],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },


                //================================================10

                new()
                {
                    Title = "Chiêu Bài Quản Lý Vàng Của Bill Gates ",
                    ShortDescription = "Chiêu Bài Quản Lý Vàng Của Bill Gates sẽ giải thích tại sao Bill Gates lại thành công đến vậy? Tại sao lịch sử lại chọn ông? Là một nhà lãnh đạo, Bill Gates đã có những phương pháp quản lý như thế nào để Microsoft không ngừng phát triển?",
                    Description = "Chiêu Bài Quản Lý Vàng Của Bill Gates sẽ giải thích tại sao Bill Gates lại thành công đến vậy? Tại sao lịch sử lại chọn ông? Là một nhà lãnh đạo, Bill Gates đã có những phương pháp quản lý như thế nào để Microsoft không ngừng phát triển",
                    Meta = "Chieu bai quan ly vang cua bill gates",
                    UrlSlug = "chieu-bai-quan-ly-vang-cua-bill-gates",
                    Published = true,
                    PostedDate = new DateTime(2021, 8, 10, 8, 30, 0),
                    ModifiedDate = null,
                    ViewCount = 995,
                    Author = authors[1],
                    Category = categories[5],
                    Tags = new List<Tag>()
                    {
                        tags[9]
                    }
                }
            };

            _dbContext.Posts.AddRange(posts);
            _dbContext.SaveChanges();

            return posts;
        }

        private IList<Book> AddBooks(
           IList<Author> authors,
           IList<Category> categories
           )
        {
            var books = new List<Book>()
            {
                new()
                {
                    Title = "Alice In Borderland - Tập 6 - Tặng Kèm Card Giấy",
                    ShortDescription = "Arisu Ryohei tự nhận mình là một thành phần “ăn hại xã hội”, học hành lẹt đẹt nên đang cực kỳ chán đời.",
                    Description = "Arisu Ryohei tự nhận mình là một thành phần “ăn hại xã hội”, học hành lẹt đẹt nên đang cực kỳ chán đời. Trong một lần tụ tập than vãn cùng hai thằng bạn thân Karube và Chota, cả ba bất chợt nhìn thấy pháo hoa, và sau đó là một vụ nổ long trời lở đất.",
                    Meta = "Alice In Borderland Tap 6",
                    UrlSlug = "toi-thay-hoa-vang-tren-co-xanh",
                    Supplier = "NXB Trẻ",
                    PublishCompany = "Trẻ",
                    CoverForm = "Bìa mềm",
                    StarNumber = 4,
                    AverageStar = 4.5f,
                    Price = 120000,
                    ReleasedDate = new DateTime(2020, 4, 21),
                    Author = authors[7],
                    Category = categories[8],
                }
                //================================================30
            };

            _dbContext.Books.AddRange(books);
            _dbContext.SaveChanges();

            return books;
        }
    }
}
