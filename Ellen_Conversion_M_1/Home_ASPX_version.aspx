<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home_ASPX_version.aspx.cs" Inherits="Ellen_Conversion_M_1.Home_ASPX_version" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ellen Smith&#39;s B&amp;B &#8211; Galway City, Ireland</title> 
	<meta charset="utf-8">
	<meta name="description"  
	content = "Ellen&#39;s B&amp;B; is located by the waterside in Galway City, on the west coast of Ireland. 
	Luxuriously refurbished. Host Ellen is always on hand with a warm Irish welcome and delicious breakfasts. 
	Non-smoking. All rooms on-suite."	> 
	
	
	
	<link rel="stylesheet"  href="stylesheet.css"   type="text/css">
	<script src="javascript/javascript1.js"      type="text/javascript">  </script>



</head>
<body>
    <form id="form1" runat="server">
        

        
			<noscript>Your browser does not have JavaScript enabled - please enable for all features of this website to work</noscript>
	
	
	<h1 class="toph1">Ellen's B&B	</h1>
    
	
<div id="wrapper"> 

		<header>		
			<img class="site-header"        src="images/background/new_banner.jpg"     alt="Ellen&#39;s B&amp;B &#8211; Galway City, Ireland" > 	
		</header>

	
		<nav>		
			<ul id="main_menu">
				<li><a class="active"  href="home.html">Home</a></li>
				<li><a href="accommodation.html">Accommodation</a></li>	
				<li><a href="sightseeing.html">Sightseeing</a></li>
				<li><a href="gallery.html">Gallery</a></li>
				<li><a href="faq.html">FAQ</a></li>	
				<li><a href="location.html">Location</a></li>
				<li><a href="contact_form.html">Contact Us</a></li>
			
				<li>  <div id="panel">		</div>			</li>    
				<li><div id="myDate">Todays Date</div>  </li>		
			</ul>		
		</nav>		

	


<div id="rightcol">
<div class="skip_banner"   id="topofpage"  role="presentation" ></div>


<main>


	<img class="roundcorners"  id="trip_advisor"  role="alert"     src="images/background/trip_advisor_logo.jpg"  alt="Trip advisor awards of excellence for 2015 & 2016">

	

	<div	role="contentinfo">
	
		<img class="roundcorners"   id="pic1"    src="images/general_area/river_view_thumb.jpg"       alt="River view from Ellen&#39;s B&amp;B &#8211; Galway City, Ireland" > 

        
     
        
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />

        
     
        
        <p class="para1"> Welcome to a unique accommodation in Co.Galway, Ireland.</p>

        <%--<a href="WebForm_Exp_1.aspx">Go to web form</a>--%>




		<p class="para1">
			Originally built for the Harbour Master nearly 200 years ago, Ellen&#39;s has been sensitively restored and now offers guest 
			accommodation in four bedrooms – all overlooking the sea. 
			Family portraits, period furniture, cosy fires and a warm Irish welcome make for a unique atmosphere of comfort and fun.
		</p>
	</div>


		<img  class="roundcorners"   id="pic2"    src="images/general_area/balcony_view_thumb.jpg"       	alt="Balcony sea view from Ellen&#39;s B&amp;B &#8211; Galway City, Ireland" > 

		<p  class="para1" role="contentinfo"  >The owner, Ellen, is always on hand for advice on fishing, golfing, riding, walking, swimming, sailing, dining, etc – all close by.</p>

		
		<p  class="para1"	role="contentinfo">
			The House, one of the oldest in the area, dates from 1820. It was originally the Harbour Master&#39;s house but later became a Franciscan monastery, 
			then a convent and finally a hotel owned by the Eyre family.
		</p>

		
		<p  class="para1"	role="contentinfo">
			All rooms are luxuriously furnished, with walnut wooden floors, 32" to 40" flat screen T.V and central heating.  
			Each room has their own private bathroom with full size bath and separate walk-in tropical rain shower.
			Also included are tea/coffee making facilities,iron and ironing board and hair dryer.All are non smoking.
		</p>



		
		<div  id="zoomBox"  role="presentation">     </div> 
		<img  class="roundcorners"   id="pic3"    src="images/other_rooms/drawing_room_thumb.jpg"   alt="Drawing room in Ellen&#39;s B&amp;B &#8211; Galway City, Ireland" > 


		
		<p  class="para1"	role="contentinfo">
			Ellen&#39;s stands right on the harbour, just 10 minutes walk from Galway centre with its multitude of friendly traditional Irish music pubs, cafes and restaurants.
			Other facilities nearby to the B&B include; Eyre Square Shopping Centre, three sandy beaches, spectacular coastal walks, variety of water sports, cycling &amp; bike hire. 
		</p>

		<p  class="para1"	role="contentinfo">Please click on the images above to enlarge.	</p>
	
	
	
		<p class="testamonial"	role="contentinfo">
			Every thing is perfect. Warm welcome from Ellen who knows to be present just when you need it.Very nice bedrooms with efficient heat and water pressure in shower !! 
			The view is just amazing. You can see Mayo, Sligo and Donegal at the same time. Throughly enjoyed our stay. (John &amp; Mary S.)
		</p>
	
	
		<a href="#topofpage">Back to top of page</a>
		

</main>	
	
    

<footer >  <!--  id="footer_navigation"  -->
	
	<div id="sitemap">Site Map:</div>
	<hr>
	<ul id="footer_navigation">

		<li><a  href = "home.html">Home</a></li>
		<li><a  href = "accommodation.html">Accommodation</a></li>	
		<li><a 	href = "sightseeing.html">Sightseeing</a></li>
		<li><a  href = "gallery.html">Gallery</a></li>
		<li><a  href = "faq.html">FAQ</a></li>	
		<li><a  href = "location.html">Location</a></li>	
		<li><a  href = "contact_form.html">Contact Form</a></li>
	</ul>	
		<p id="footer_text">Copyright &copy; 2017 DBS Designs</p>

</footer>


</div>
</div> 
        


    </form>
</body>
</html>
