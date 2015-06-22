namespace KLFBlog.Migrations
{
    using KLFBlog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KLFBlog.DAL.KLFBlogDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "KLFBlog.DAL.KLFBlogDb";
        }

        protected override void Seed(KLFBlog.DAL.KLFBlogDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Users.Any(u => u.UserName == "kyle.l.frisbie@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "kyle.l.frisbie@gmail.com" };

                manager.Create(user, "ksbie.Admin123");
            }

            context.BlogPosts.AddOrUpdate(b => b.Title,
                new BlogPost { Title = "Lorem", SubTitle = "Proin", Date = DateTime.Now, Image = "", PostBody = "Mauris tincidunt varius dignissim. Ut rutrum nunc id ante venenatis faucibus. Ut lacinia orci justo, in porttitor turpis iaculis quis. Curabitur blandit sit amet felis vel ultrices. Nam ac lacus imperdiet, pellentesque mauris nec, condimentum tellus. Sed tincidunt erat arcu. Donec pulvinar odio non lorem mattis, ac pulvinar leo mattis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam vehicula eget nisi vitae vehicula. Integer hendrerit orci non facilisis vestibulum. Cras vel nunc nec est consectetur viverra." },
                new BlogPost { Title = "ipsum", SubTitle = "dictum", Date = DateTime.Now, Image = "", PostBody = "Nam sit amet aliquam leo. Pellentesque bibendum dictum euismod. Quisque facilisis urna nunc, ac feugiat erat tristique non. Nunc ultricies elit et nisl congue hendrerit. Cras in pretium eros. Nulla dapibus auctor leo molestie congue. Aliquam iaculis mi ac velit congue molestie. In tempus magna ut elementum placerat. Maecenas erat libero, maximus finibus tempus eu, mollis at erat. Nam eu felis nibh. Cras neque neque, dictum a blandit eu, tempus id ligula. Nunc auctor sollicitudin leo ut vehicula. Fusce sollicitudin faucibus eleifend." },
                new BlogPost { Title = "dolor", SubTitle = "ultricies", Date = DateTime.Now, Image = "", PostBody = "Fusce vel neque luctus, condimentum tellus eu, sodales tortor. Donec rhoncus ipsum in felis vulputate pellentesque. In aliquam elit in augue porta, eget sollicitudin nibh tempor. Vestibulum congue laoreet porttitor. Fusce sit amet quam vulputate, sodales nisl nec, volutpat justo. Etiam finibus lorem non neque pharetra fringilla. Cras ac imperdiet lorem, sit amet pellentesque magna. Suspendisse ut tellus ligula. Sed semper ante elit, sed auctor turpis malesuada ut. Morbi sollicitudin suscipit molestie." },
                new BlogPost { Title = "sit", SubTitle = "quam", Date = DateTime.Now, Image = "", PostBody = "Vivamus mattis ullamcorper quam non aliquet. Proin porttitor, odio vitae rhoncus aliquet, augue leo volutpat augue, vitae rhoncus nunc lacus sed sapien. Ut vitae tellus sed erat mollis pellentesque at vel libero. Quisque ac mollis quam, nec pulvinar nisi. Mauris in risus tellus. Aliquam quis gravida nulla. Aliquam finibus arcu eget risus aliquet, vel feugiat ipsum gravida. Aliquam fermentum felis in ipsum porttitor dapibus. In mi tortor, imperdiet id mattis ac, mollis eget ante. Integer semper ut leo sed elementum. Cras eleifend pellentesque finibus. Suspendisse posuere interdum volutpat." },
                new BlogPost { Title = "amet", SubTitle = "nec", Date = DateTime.Now, Image = "", PostBody = "Vestibulum vel tempus risus, vitae pellcentesque nunc. In hac habitasse platea dictumst. Ut sem ligula, sagittis ut placerat ut, iaculis luctus odio. Fusce ut tortor sem. Donec dictum ullamcorper ultricies. Proin bibendum velit vitae scelerisque lacinia. Integer scelerisque molestie ullamcorper. Sed consequat purus quis enim eleifend, quis ultrices neque ultrices. Nulla in erat magna. Quisque non bibendum arcu." },
                new BlogPost { Title = "consectetur", SubTitle = "aliquet", Date = DateTime.Now, Image = "", PostBody = "Mauris ultrices lorem eros, ac sollicitudin quam accumsan vitae. Vestibulum faucibus, ipsum eu posuere scelerisque, erat dolor consectetur magna, eu consequat quam lorem non eros. Maecenas vestibulum interdum lacus eu tristique. Maecenas bibendum odio ut justo maximus, sed porta turpis molestie. Nam vitae metus ut tortor suscipit viverra. Nullam tempus tortor id lectus porta elementum. Integer vitae fermentum turpis. Maecenas tempor vel metus in consequat. In non erat in arcu imperdiet blandit vitae at urna. Aliquam ac neque scelerisque, mattis augue at, hendrerit libero. Mauris tristique nisl scelerisque, convallis nisi in, rhoncus ex. In vel mi eu nisl lobortis lacinia sed nec leo. Donec aliquam vestibulum nisl eu pellentesque. Nullam aliquet tincidunt maximus." },
                new BlogPost { Title = "adipiscing", SubTitle = "Interdum", Date = DateTime.Now, Image = "", PostBody = "Fusce ultricies augue eu cursus vulputate. Curabitur quam nisi, pellentesque at enim condimentum, ultricies commodo lorem. Ut ullamcorper nulla augue, quis laoreet sem fringilla sit amet. Fusce ipsum urna, porttitor vestibulum leo et, tristique fringilla justo. Proin sagittis quis libero sollicitudin maximus. Sed consectetur pulvinar libero, at efficitur tellus mattis non. Suspendisse rhoncus turpis eget nunc finibus accumsan id eu sem. Nunc semper commodo elit vitae bibendum. Donec at elementum arcu. Nunc rhoncus libero id faucibus fermentum. Maecenas luctus neque at lorem egestas, sit amet eleifend augue porta. Quisque leo nunc, aliquet faucibus metus sit amet, luctus porta justo." },
                new BlogPost { Title = "elit", SubTitle = "et", Date = DateTime.Now, Image = "", PostBody = "Quisque nisl purus, bibendum id mauris id, facilisis posuere turpis. Phasellus vel mauris ac lectus aliquam ultrices ut quis odio. Donec finibus eros vel consequat malesuada. Curabitur sollicitudin leo nisl, sed imperdiet tortor consectetur sit amet. Nam scelerisque urna lacus, non luctus ligula sodales non. In eu odio a metus ultrices convallis. Etiam vulputate faucibus sem, non malesuada ligula convallis vehicula. Nulla porttitor congue libero, id pretium erat pellentesque ut. Sed id semper lorem, nec efficitur diam. Aliquam sodales porttitor massa sit amet lacinia. Quisque in suscipit nisl. Fusce fringilla orci est, in consectetur tortor elementum sed. Suspendisse aliquet turpis at nulla molestie, in condimentum justo condimentum. Sed at diam sit amet nulla vehicula tempus. Aliquam eu hendrerit ipsum. Mauris nec tincidunt velit." },
                new BlogPost { Title = "Quisque", SubTitle = "malesuada", Date = DateTime.Now, Image = "", PostBody = "Donec a convallis urna. Vestibulum ullamcorper egestas imperdiet. Cras nunc tellus, consequat vitae elementum vel, tempus ut velit. Cras est arcu, aliquet ac quam quis, efficitur cursus leo. Pellentesque lacinia neque in molestie dictum. Pellentesque interdum ante sit amet leo fringilla, ut venenatis nulla venenatis. Nam pharetra congue elit, vitae finibus magna." },
                new BlogPost { Title = "cursus", SubTitle = "fames", Date = DateTime.Now, Image = "", PostBody = "Aenean vel justo tincidunt, interdum ligula nec, tincidunt massa. Nulla facilisi. Nulla placerat eros orci, in efficitur nibh bibendum sed. Fusce imperdiet, justo at pretium venenatis, metus velit efficitur urna, et euismod erat nisi sed nunc. Sed vulputate felis et magna mollis tristique. Sed vehicula odio et urna bibendum, ut sodales mi elementum. Mauris dapibus auctor nulla non auctor. Donec laoreet dolor nisi, nec laoreet nibh laoreet id." },
                new BlogPost { Title = "eu", SubTitle = "ac", Date = DateTime.Now, Image = "", PostBody = "Fusce malesuada est ut nunc scelerisque, quis egestas libero commodo. Phasellus ex leo, imperdiet ut pellentesque quis, elementum vitae libero. Aliquam tempor molestie neque, et accumsan nibh malesuada in. Curabitur at aliquet est, ut egestas justo. Suspendisse eu nisl et ante efficitur egestas eget at justo. In tortor nisi, dignissim semper efficitur iaculis, dapibus nec urna. Maecenas purus purus, venenatis vitae laoreet vitae, ultrices quis tortor. Proin sed purus ut est eleifend luctus sed vel turpis. Duis ornare est sed dictum auctor. Nullam ornare libero eget elementum sollicitudin. Sed et ultricies erat. Nullam a consequat orci." },
                new BlogPost { Title = "libero", SubTitle = "ante", Date = DateTime.Now, Image = "", PostBody = "Vivamus quam leo, mollis et arcu pharetra, posuere ornare tellus. Aenean porta, lorem quis dapibus lobortis, erat quam consequat ex, sit amet dapibus quam elit vitae nunc. Quisque tristique libero vel nibh semper, fringilla sollicitudin justo tempor. Nam ultrices augue id neque semper, quis luctus diam cursus. Sed vestibulum, ante sed auctor egestas, velit risus volutpat ligula, eget ornare purus sem nec erat. Maecenas euismod consectetur enim, nec vehicula metus. Aenean in nisl auctor, pharetra ex sed, mattis nisl. Interdum et malesuada fames ac ante ipsum primis in faucibus. Phasellus pellentesque bibendum ante in sagittis. Mauris sed nisl id sem dictum luctus. Aenean congue nunc at quam ullamcorper, nec cursus mauris convallis. Maecenas molestie lectus aliquam elit sagittis ultricies. Phasellus a justo ultrices, congue diam quis, elementum neque. Phasellus pharetra odio vitae risus viverra aliquam. Praesent eget leo eu tortor bibendum dignissim eget non sapien. Quisque finibus dapibus enim, et maximus sem semper quis." },
                new BlogPost { Title = "a", SubTitle = "ipsum", Date = DateTime.Now, Image = "", PostBody = "Mauris sit amet pretium libero. Duis accumsan erat ut mollis venenatis. In condimentum urna vitae odio vestibulum, ut rutrum ipsum consectetur. Nam eget felis ultricies, pellentesque neque vel, dictum libero. Nullam porttitor mi vitae lacinia molestie. Nunc pulvinar sapien sapien, in congue ligula elementum vel. Duis tempus quam libero, nec laoreet quam varius vel. Quisque porta laoreet nisi, eu egestas velit sodales quis. Pellentesque orci augue, vehicula ut mi a, gravida tincidunt augue. Nulla tincidunt tellus nec metus tincidunt, eget vulputate erat commodo. Etiam metus sem, faucibus eget malesuada ut, facilisis non ex. Integer viverra nec quam quis interdum." },
                new BlogPost { Title = "laoreet", SubTitle = "primis", Date = DateTime.Now, Image = "", PostBody = "Aenean nisi dui, aliquet vitae odio eget, volutpat tempus dolor. Sed a velit felis. Integer tempor sapien lorem, ut sollicitudin magna vehicula id. Pellentesque ut erat suscipit, ullamcorper quam in, scelerisque diam. Morbi cursus, ipsum vitae hendrerit porta, felis enim posuere lorem, nec semper ex turpis vel erat. Donec blandit eros quis tellus finibus scelerisque. Vivamus convallis euismod massa quis suscipit. Proin placerat, leo vitae aliquam auctor, augue magna tempus lorem, a vulputate ex nulla et sem. Vivamus et arcu eu risus egestas accumsan eget vel turpis. Nulla commodo rutrum euismod. Cras ultrices euismod commodo. Vivamus egestas eget ante sit amet dapibus. Cras erat lorem, efficitur dictum congue eget, porta et eros. Nulla dictum neque in pharetra faucibus." },
                new BlogPost { Title = "Fusce", SubTitle = "in", Date = DateTime.Now, Image = "", PostBody = "Quisque lectus turpis, ornare sit amet condimentum ut, aliquam eget arcu. Nunc facilisis sem eu est vestibulum, sit amet maximus ex varius. Mauris ultrices, nulla vel aliquet dapibus, mi purus fringilla est, quis maximus mi augue id risus. Vestibulum aliquet mattis augue, a faucibus turpis sollicitudin quis. Ut accumsan euismod laoreet. Nam mollis vel elit ut maximus. Donec eget pellentesque quam, consequat iaculis enim. In accumsan mattis massa, ac eleifend lacus lobortis sed. Fusce tincidunt non sem vel ornare. Cras id urna ultrices nisl porta lacinia. Vivamus in sapien quis risus laoreet malesuada at et dui. Etiam iaculis elit purus. Phasellus vel lacinia est." },
                new BlogPost { Title = "molestie", SubTitle = "faucibus", Date = DateTime.Now, Image = "", PostBody = "Curabitur vulputate iaculis nisi, vel faucibus tortor fringilla ac. Suspendisse pharetra massa non purus dignissim, vel feugiat quam molestie. Vivamus non nisl turpis. Ut sit amet lectus mollis, facilisis ex sed, ornare dui. Vivamus porta erat felis, ut rhoncus felis iaculis sollicitudin. Phasellus sed sem quis turpis venenatis commodo et quis dui. Fusce tempor lacus at purus egestas pretium. Ut rhoncus leo vitae mauris finibus, id porttitor nisi viverra. Quisque id blandit purus, eu accumsan nibh. Phasellus sed ante nisl. Morbi non urna blandit, sagittis massa nec, congue erat. Sed tristique, justo ac varius tempus, magna nisl varius urna, nec commodo urna mi at eros. Nunc et pulvinar neque." },
                new BlogPost { Title = "et", SubTitle = "Proin", Date = DateTime.Now, Image = "", PostBody = "Donec tincidunt, enim a accumsan convallis, neque ipsum ornare mauris, in gravida ligula dolor non tellus. Suspendisse scelerisque facilisis nisi et ultricies. Integer sit amet tellus suscipit, congue augue in, pretium turpis. In tristique sapien sit amet ex congue dictum. In hac habitasse platea dictumst. Aliquam erat volutpat. Aliquam sagittis vitae felis in ultrices. Aliquam erat volutpat. Nullam condimentum eros ac velit condimentum pellentesque. Aenean accumsan dictum neque ut rutrum. Nulla fermentum pulvinar dui hendrerit consectetur. Aenean pharetra tristique justo, vitae commodo enim pulvinar a." },
                new BlogPost { Title = "massa", SubTitle = "ultricies", Date = DateTime.Now, Image = "", PostBody = "Donec diam ipsum, pulvinar quis metus ut, fermentum eleifend nibh. Phasellus placerat fermentum commodo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam efficitur dolor ut aliquam tristique. Praesent risus urna, euismod elementum varius vel, mattis in justo. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vulputate justo eget mauris ultricies vestibulum. Phasellus varius lectus orci, non vestibulum urna sollicitudin eget. Vestibulum mauris ipsum, tristique quis sem et, laoreet sodales tortor. Nulla molestie turpis a condimentum iaculis." },
                new BlogPost { Title = "vitae ", SubTitle = "metus", Date = DateTime.Now, Image = "", PostBody = "Curabitur et venenatis elit. Nunc nec tincidunt nisi. Aenean dictum, est quis elementum pretium, metus risus vestibulum erat, ut sollicitudin diam sapien eu tellus. Nunc nec augue urna. Nullam sed sem iaculis, porttitor metus in, bibendum est. Proin fermentum at justo nec volutpat. Donec laoreet nibh tortor, sed pharetra nunc pharetra eget. Praesent ut ex consectetur, efficitur magna et, scelerisque sapien. Vestibulum nec quam accumsan, convallis nibh a, dignissim ante. Nam feugiat, ligula quis porttitor faucibus, neque metus ullamcorper erat, ac ultricies nulla mi ut neque." },
                new BlogPost { Title = "dapibus", SubTitle = "gravida", Date = DateTime.Now, Image = "", PostBody = "Aenean ornare tellus vel ligula scelerisque egestas. Maecenas ut nibh sed lacus feugiat dapibus. Aenean feugiat tortor quis lacus fringilla porttitor. Duis congue erat in suscipit rhoncus. Maecenas a arcu eget orci ultrices tristique nec vitae enim. Aliquam nunc nibh, semper at diam elementum, maximus luctus ante. Duis et leo arcu. Pellentesque malesuada sapien eget mi molestie tempor. Proin nibh mi, iaculis vel arcu id, sodales elementum nisl." }

            );

            context.Projects.AddOrUpdate(p => p.Title,
                new Project { Title = "Lorem", SubTitle = "Proin", Date = DateTime.Now, Image = "", PostBody = "Mauris tincidunt varius dignissim. Ut rutrum nunc id ante venenatis faucibus. Ut lacinia orci justo, in porttitor turpis iaculis quis. Curabitur blandit sit amet felis vel ultrices. Nam ac lacus imperdiet, pellentesque mauris nec, condimentum tellus. Sed tincidunt erat arcu. Donec pulvinar odio non lorem mattis, ac pulvinar leo mattis. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam vehicula eget nisi vitae vehicula. Integer hendrerit orci non facilisis vestibulum. Cras vel nunc nec est consectetur viverra." },
                new Project { Title = "ipsum", SubTitle = "dictum", Date = DateTime.Now, Image = "", PostBody = "Nam sit amet aliquam leo. Pellentesque bibendum dictum euismod. Quisque facilisis urna nunc, ac feugiat erat tristique non. Nunc ultricies elit et nisl congue hendrerit. Cras in pretium eros. Nulla dapibus auctor leo molestie congue. Aliquam iaculis mi ac velit congue molestie. In tempus magna ut elementum placerat. Maecenas erat libero, maximus finibus tempus eu, mollis at erat. Nam eu felis nibh. Cras neque neque, dictum a blandit eu, tempus id ligula. Nunc auctor sollicitudin leo ut vehicula. Fusce sollicitudin faucibus eleifend." },
                new Project { Title = "dolor", SubTitle = "ultricies", Date = DateTime.Now, Image = "", PostBody = "Fusce vel neque luctus, condimentum tellus eu, sodales tortor. Donec rhoncus ipsum in felis vulputate pellentesque. In aliquam elit in augue porta, eget sollicitudin nibh tempor. Vestibulum congue laoreet porttitor. Fusce sit amet quam vulputate, sodales nisl nec, volutpat justo. Etiam finibus lorem non neque pharetra fringilla. Cras ac imperdiet lorem, sit amet pellentesque magna. Suspendisse ut tellus ligula. Sed semper ante elit, sed auctor turpis malesuada ut. Morbi sollicitudin suscipit molestie." },
                new Project { Title = "sit", SubTitle = "quam", Date = DateTime.Now, Image = "", PostBody = "Vivamus mattis ullamcorper quam non aliquet. Proin porttitor, odio vitae rhoncus aliquet, augue leo volutpat augue, vitae rhoncus nunc lacus sed sapien. Ut vitae tellus sed erat mollis pellentesque at vel libero. Quisque ac mollis quam, nec pulvinar nisi. Mauris in risus tellus. Aliquam quis gravida nulla. Aliquam finibus arcu eget risus aliquet, vel feugiat ipsum gravida. Aliquam fermentum felis in ipsum porttitor dapibus. In mi tortor, imperdiet id mattis ac, mollis eget ante. Integer semper ut leo sed elementum. Cras eleifend pellentesque finibus. Suspendisse posuere interdum volutpat." },
                new Project { Title = "amet", SubTitle = "nec", Date = DateTime.Now, Image = "", PostBody = "Vestibulum vel tempus risus, vitae pellcentesque nunc. In hac habitasse platea dictumst. Ut sem ligula, sagittis ut placerat ut, iaculis luctus odio. Fusce ut tortor sem. Donec dictum ullamcorper ultricies. Proin bibendum velit vitae scelerisque lacinia. Integer scelerisque molestie ullamcorper. Sed consequat purus quis enim eleifend, quis ultrices neque ultrices. Nulla in erat magna. Quisque non bibendum arcu." },
                new Project { Title = "consectetur", SubTitle = "aliquet", Date = DateTime.Now, Image = "", PostBody = "Mauris ultrices lorem eros, ac sollicitudin quam accumsan vitae. Vestibulum faucibus, ipsum eu posuere scelerisque, erat dolor consectetur magna, eu consequat quam lorem non eros. Maecenas vestibulum interdum lacus eu tristique. Maecenas bibendum odio ut justo maximus, sed porta turpis molestie. Nam vitae metus ut tortor suscipit viverra. Nullam tempus tortor id lectus porta elementum. Integer vitae fermentum turpis. Maecenas tempor vel metus in consequat. In non erat in arcu imperdiet blandit vitae at urna. Aliquam ac neque scelerisque, mattis augue at, hendrerit libero. Mauris tristique nisl scelerisque, convallis nisi in, rhoncus ex. In vel mi eu nisl lobortis lacinia sed nec leo. Donec aliquam vestibulum nisl eu pellentesque. Nullam aliquet tincidunt maximus." },
                new Project { Title = "adipiscing", SubTitle = "Interdum", Date = DateTime.Now, Image = "", PostBody = "Fusce ultricies augue eu cursus vulputate. Curabitur quam nisi, pellentesque at enim condimentum, ultricies commodo lorem. Ut ullamcorper nulla augue, quis laoreet sem fringilla sit amet. Fusce ipsum urna, porttitor vestibulum leo et, tristique fringilla justo. Proin sagittis quis libero sollicitudin maximus. Sed consectetur pulvinar libero, at efficitur tellus mattis non. Suspendisse rhoncus turpis eget nunc finibus accumsan id eu sem. Nunc semper commodo elit vitae bibendum. Donec at elementum arcu. Nunc rhoncus libero id faucibus fermentum. Maecenas luctus neque at lorem egestas, sit amet eleifend augue porta. Quisque leo nunc, aliquet faucibus metus sit amet, luctus porta justo." },
                new Project { Title = "elit", SubTitle = "et", Date = DateTime.Now, Image = "", PostBody = "Quisque nisl purus, bibendum id mauris id, facilisis posuere turpis. Phasellus vel mauris ac lectus aliquam ultrices ut quis odio. Donec finibus eros vel consequat malesuada. Curabitur sollicitudin leo nisl, sed imperdiet tortor consectetur sit amet. Nam scelerisque urna lacus, non luctus ligula sodales non. In eu odio a metus ultrices convallis. Etiam vulputate faucibus sem, non malesuada ligula convallis vehicula. Nulla porttitor congue libero, id pretium erat pellentesque ut. Sed id semper lorem, nec efficitur diam. Aliquam sodales porttitor massa sit amet lacinia. Quisque in suscipit nisl. Fusce fringilla orci est, in consectetur tortor elementum sed. Suspendisse aliquet turpis at nulla molestie, in condimentum justo condimentum. Sed at diam sit amet nulla vehicula tempus. Aliquam eu hendrerit ipsum. Mauris nec tincidunt velit." },
                new Project { Title = "Quisque", SubTitle = "malesuada", Date = DateTime.Now, Image = "", PostBody = "Donec a convallis urna. Vestibulum ullamcorper egestas imperdiet. Cras nunc tellus, consequat vitae elementum vel, tempus ut velit. Cras est arcu, aliquet ac quam quis, efficitur cursus leo. Pellentesque lacinia neque in molestie dictum. Pellentesque interdum ante sit amet leo fringilla, ut venenatis nulla venenatis. Nam pharetra congue elit, vitae finibus magna." },
                new Project { Title = "cursus", SubTitle = "fames", Date = DateTime.Now, Image = "", PostBody = "Aenean vel justo tincidunt, interdum ligula nec, tincidunt massa. Nulla facilisi. Nulla placerat eros orci, in efficitur nibh bibendum sed. Fusce imperdiet, justo at pretium venenatis, metus velit efficitur urna, et euismod erat nisi sed nunc. Sed vulputate felis et magna mollis tristique. Sed vehicula odio et urna bibendum, ut sodales mi elementum. Mauris dapibus auctor nulla non auctor. Donec laoreet dolor nisi, nec laoreet nibh laoreet id." },
                new Project { Title = "eu", SubTitle = "ac", Date = DateTime.Now, Image = "", PostBody = "Fusce malesuada est ut nunc scelerisque, quis egestas libero commodo. Phasellus ex leo, imperdiet ut pellentesque quis, elementum vitae libero. Aliquam tempor molestie neque, et accumsan nibh malesuada in. Curabitur at aliquet est, ut egestas justo. Suspendisse eu nisl et ante efficitur egestas eget at justo. In tortor nisi, dignissim semper efficitur iaculis, dapibus nec urna. Maecenas purus purus, venenatis vitae laoreet vitae, ultrices quis tortor. Proin sed purus ut est eleifend luctus sed vel turpis. Duis ornare est sed dictum auctor. Nullam ornare libero eget elementum sollicitudin. Sed et ultricies erat. Nullam a consequat orci." },
                new Project { Title = "libero", SubTitle = "ante", Date = DateTime.Now, Image = "", PostBody = "Vivamus quam leo, mollis et arcu pharetra, posuere ornare tellus. Aenean porta, lorem quis dapibus lobortis, erat quam consequat ex, sit amet dapibus quam elit vitae nunc. Quisque tristique libero vel nibh semper, fringilla sollicitudin justo tempor. Nam ultrices augue id neque semper, quis luctus diam cursus. Sed vestibulum, ante sed auctor egestas, velit risus volutpat ligula, eget ornare purus sem nec erat. Maecenas euismod consectetur enim, nec vehicula metus. Aenean in nisl auctor, pharetra ex sed, mattis nisl. Interdum et malesuada fames ac ante ipsum primis in faucibus. Phasellus pellentesque bibendum ante in sagittis. Mauris sed nisl id sem dictum luctus. Aenean congue nunc at quam ullamcorper, nec cursus mauris convallis. Maecenas molestie lectus aliquam elit sagittis ultricies. Phasellus a justo ultrices, congue diam quis, elementum neque. Phasellus pharetra odio vitae risus viverra aliquam. Praesent eget leo eu tortor bibendum dignissim eget non sapien. Quisque finibus dapibus enim, et maximus sem semper quis." },
                new Project { Title = "a", SubTitle = "ipsum", Date = DateTime.Now, Image = "", PostBody = "Mauris sit amet pretium libero. Duis accumsan erat ut mollis venenatis. In condimentum urna vitae odio vestibulum, ut rutrum ipsum consectetur. Nam eget felis ultricies, pellentesque neque vel, dictum libero. Nullam porttitor mi vitae lacinia molestie. Nunc pulvinar sapien sapien, in congue ligula elementum vel. Duis tempus quam libero, nec laoreet quam varius vel. Quisque porta laoreet nisi, eu egestas velit sodales quis. Pellentesque orci augue, vehicula ut mi a, gravida tincidunt augue. Nulla tincidunt tellus nec metus tincidunt, eget vulputate erat commodo. Etiam metus sem, faucibus eget malesuada ut, facilisis non ex. Integer viverra nec quam quis interdum." },
                new Project { Title = "laoreet", SubTitle = "primis", Date = DateTime.Now, Image = "", PostBody = "Aenean nisi dui, aliquet vitae odio eget, volutpat tempus dolor. Sed a velit felis. Integer tempor sapien lorem, ut sollicitudin magna vehicula id. Pellentesque ut erat suscipit, ullamcorper quam in, scelerisque diam. Morbi cursus, ipsum vitae hendrerit porta, felis enim posuere lorem, nec semper ex turpis vel erat. Donec blandit eros quis tellus finibus scelerisque. Vivamus convallis euismod massa quis suscipit. Proin placerat, leo vitae aliquam auctor, augue magna tempus lorem, a vulputate ex nulla et sem. Vivamus et arcu eu risus egestas accumsan eget vel turpis. Nulla commodo rutrum euismod. Cras ultrices euismod commodo. Vivamus egestas eget ante sit amet dapibus. Cras erat lorem, efficitur dictum congue eget, porta et eros. Nulla dictum neque in pharetra faucibus." },
                new Project { Title = "Fusce", SubTitle = "in", Date = DateTime.Now, Image = "", PostBody = "Quisque lectus turpis, ornare sit amet condimentum ut, aliquam eget arcu. Nunc facilisis sem eu est vestibulum, sit amet maximus ex varius. Mauris ultrices, nulla vel aliquet dapibus, mi purus fringilla est, quis maximus mi augue id risus. Vestibulum aliquet mattis augue, a faucibus turpis sollicitudin quis. Ut accumsan euismod laoreet. Nam mollis vel elit ut maximus. Donec eget pellentesque quam, consequat iaculis enim. In accumsan mattis massa, ac eleifend lacus lobortis sed. Fusce tincidunt non sem vel ornare. Cras id urna ultrices nisl porta lacinia. Vivamus in sapien quis risus laoreet malesuada at et dui. Etiam iaculis elit purus. Phasellus vel lacinia est." },
                new Project { Title = "molestie", SubTitle = "faucibus", Date = DateTime.Now, Image = "", PostBody = "Curabitur vulputate iaculis nisi, vel faucibus tortor fringilla ac. Suspendisse pharetra massa non purus dignissim, vel feugiat quam molestie. Vivamus non nisl turpis. Ut sit amet lectus mollis, facilisis ex sed, ornare dui. Vivamus porta erat felis, ut rhoncus felis iaculis sollicitudin. Phasellus sed sem quis turpis venenatis commodo et quis dui. Fusce tempor lacus at purus egestas pretium. Ut rhoncus leo vitae mauris finibus, id porttitor nisi viverra. Quisque id blandit purus, eu accumsan nibh. Phasellus sed ante nisl. Morbi non urna blandit, sagittis massa nec, congue erat. Sed tristique, justo ac varius tempus, magna nisl varius urna, nec commodo urna mi at eros. Nunc et pulvinar neque." },
                new Project { Title = "et", SubTitle = "Proin", Date = DateTime.Now, Image = "", PostBody = "Donec tincidunt, enim a accumsan convallis, neque ipsum ornare mauris, in gravida ligula dolor non tellus. Suspendisse scelerisque facilisis nisi et ultricies. Integer sit amet tellus suscipit, congue augue in, pretium turpis. In tristique sapien sit amet ex congue dictum. In hac habitasse platea dictumst. Aliquam erat volutpat. Aliquam sagittis vitae felis in ultrices. Aliquam erat volutpat. Nullam condimentum eros ac velit condimentum pellentesque. Aenean accumsan dictum neque ut rutrum. Nulla fermentum pulvinar dui hendrerit consectetur. Aenean pharetra tristique justo, vitae commodo enim pulvinar a." },
                new Project { Title = "massa", SubTitle = "ultricies", Date = DateTime.Now, Image = "", PostBody = "Donec diam ipsum, pulvinar quis metus ut, fermentum eleifend nibh. Phasellus placerat fermentum commodo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam efficitur dolor ut aliquam tristique. Praesent risus urna, euismod elementum varius vel, mattis in justo. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Curabitur vulputate justo eget mauris ultricies vestibulum. Phasellus varius lectus orci, non vestibulum urna sollicitudin eget. Vestibulum mauris ipsum, tristique quis sem et, laoreet sodales tortor. Nulla molestie turpis a condimentum iaculis." },
                new Project { Title = "vitae ", SubTitle = "metus", Date = DateTime.Now, Image = "", PostBody = "Curabitur et venenatis elit. Nunc nec tincidunt nisi. Aenean dictum, est quis elementum pretium, metus risus vestibulum erat, ut sollicitudin diam sapien eu tellus. Nunc nec augue urna. Nullam sed sem iaculis, porttitor metus in, bibendum est. Proin fermentum at justo nec volutpat. Donec laoreet nibh tortor, sed pharetra nunc pharetra eget. Praesent ut ex consectetur, efficitur magna et, scelerisque sapien. Vestibulum nec quam accumsan, convallis nibh a, dignissim ante. Nam feugiat, ligula quis porttitor faucibus, neque metus ullamcorper erat, ac ultricies nulla mi ut neque." },
                new Project { Title = "dapibus", SubTitle = "gravida", Date = DateTime.Now, Image = "", PostBody = "Aenean ornare tellus vel ligula scelerisque egestas. Maecenas ut nibh sed lacus feugiat dapibus. Aenean feugiat tortor quis lacus fringilla porttitor. Duis congue erat in suscipit rhoncus. Maecenas a arcu eget orci ultrices tristique nec vitae enim. Aliquam nunc nibh, semper at diam elementum, maximus luctus ante. Duis et leo arcu. Pellentesque malesuada sapien eget mi molestie tempor. Proin nibh mi, iaculis vel arcu id, sodales elementum nisl." }

            );
        }
    }
}