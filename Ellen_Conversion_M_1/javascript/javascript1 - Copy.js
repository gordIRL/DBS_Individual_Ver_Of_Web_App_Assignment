	
/*   Javacript for web CA: 10352606   */





/*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/

/* call Javascript on each page using document.addEventListener INSTEAD of window.onload */


document.addEventListener("DOMContentLoaded" , mainfunctions, 	false);
document.addEventListener("DOMContentLoaded" , homePage, 		false);
document.addEventListener("DOMContentLoaded" , galleryPage,		false);
document.addEventListener("DOMContentLoaded" , contactPageForm,	false);



/*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/
/* these functions package together groups of logically related smaller functions  */

function mainfunctions()   {

	directionalNavigation();
	displayDate();
}  // end mainfunctions		
	
	
	
function homePage()   {	
	changeTripAdvisorInfo();  
	enlargeImage();  
}  // end homePage		

	
	
function galleryPage()   {
	mySlideShow();		
}  // end GalleryPage	
		



function contactPageForm()   {
	validateForm;						/*  () is not needed here - don't want the function to be called at page load time !!  */
}  // end GalleryPage		
	
	

/*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/

	
	
	
	
	
	
	
	
/* function to validate user's input to the form on the contact page   			*/
/* using this instead of the HTML tag 'REQUIRED' so as to have compatibility with wider selection of browsers  */

			
function validateForm()
	{

	
document.getElementById("contact_form").onsubmit   = function() { validateForm() };	
	
	
/* 	alert(str.trim());  */
	
		/*   alert ("now validating the form !!");    */
		
		var first_name 	= document.forms[0].first_name.value.trim();  				/*1st form is at [0]  2nd form is at [1] etc. !!!  */
		var surname 	= document.forms[0].surname.valuetrim(); 
		var useremail 	= document.forms[0].useremail.valuetrim(); 
		var phone 		= document.forms[0].phone.valuetrim();
		
/*  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx	*/	

		if (first_name=="")
		{
			while (first_name=="")
					{						
						first_name = prompt("Oops!!  Name can't be blank - please enter again.")		
					} 
		}
		
/*  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx	*/		
				
		if (surname=="")
		{
			while (surname=="")
					{						
						surname = prompt("Oops!!  Surname can't be blank - please enter again.")		
					} 
		}		
		
/*  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx	*/	


		if (useremail=="")
		{
			while (useremail=="" ||  (useremail.indexOf("@") ===-1)    ||    (useremail.indexOf(".") ===-1)            )
					{						
						useremail = prompt("Oops!!  Please enter a valid email address.")						
					} 
		}		
	
		
/*  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx	*/	

		if (phone=="")
		{
			while (phone=="")
					{						
						phone = prompt("Oops!!  Phone number can't be blank - please enter again.")		
					} 
		}		
				
/*  xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx	*/			
			
		
	} // end validateForm  
		
		

	/*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/
	
	
	
	
	
	
	
	
	
	
/* function to provide functionality for the image gallery on the Gallery Page */	
	
	
function mySlideShow()  {
		
document.getElementById("backwards").onclick   = function() { plusDivs(-1) };	
document.getElementById("forwards").onclick    = function() { plusDivs(+1) };		
		
var slideIndex = 1;
showDivs(slideIndex);

function plusDivs(n) {
  showDivs(slideIndex += n);
}	
	
function showDivs(n) {
  var i;
  var x = document.getElementsByClassName("mySlides");
  if (n > x.length) {slideIndex = 1}    					/* go past all slides - reset & start again  */
  if (n < 1) {slideIndex = x.length}						/* less than 1st slide - then go to last slide */
  for (i = 0; i < x.length; i++) {
     x[i].style.display = "none";  							/* loop through array 'x' of slides and hide / blank them out */				
  }
  x[slideIndex-1].style.display = "block";  				/* display current image - (-1) because arrays are zero based!!  */
}

} //end mySlideShow	
		
	
		
/*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/





		



/*  function to display Trip Advisor information on the HOME page    */	
	
	
function changeTripAdvisorInfo() {	document.getElementById("trip_advisor").onmouseover = function() {tripAlert()};	}  	// end change_trip_advisor_info		
	
function tripAlert()	{ alert("Awarded Trip Advisor Certificate of Excellence 2015 & 2016.");  } 	// end trip_alert	
	
	
	
/*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/
	
	
	
	
	
	
/* mouse over function to enlarge images on the HOME page    */	
	
function enlargeImage()  {	
	var box;
	box = document.getElementById("zoomBox");
		
	var pic1 = document.getElementById("pic1");
	pic1.onmouseover = zoomIn;
	pic1.onmouseout = zoomOut;
	
	
	var pic2 = document.getElementById("pic2");
	pic2.onmouseover = zoomIn;
	pic2.onmouseout = zoomOut;
	
	
	var pic3 = document.getElementById("pic3");
	pic3.onmouseover = zoomIn;
	pic3.onmouseout = zoomOut;
	
	var pic4 = document.getElementById("chad");
	pic4.onmouseover = zoomIn;
	pic4.onmouseout = zoomOut;

	
function zoomIn()	{	var filename = this.src.split("_thumb.jpg");
						box.style.background = "url(" + filename[ 0 ] + ".jpg)";  }

function zoomOut()	{	box.style.background = "inherit";	}
		
}  // end enlargeImage
	
	
/*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/


		
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
/* functionality to enable forward & backwards a page - on the Navigation Selection (left side of screen)   */

function directionalNavigation()  {

	var panel = document.getElementById("panel");
	panel.innerHTML +=  "<button onclick='history.back()'   >Back   </button>";
	panel.innerHTML +=  "<button onclick='history.forward()'>Forward</button>";
}  //  end directionalNavigation


/*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/













	
/* functionality to display current date - on the Navigation Selection (left side of screen)   */	
	
function displayDate()  {	

	var myDate = document.getElementById("myDate");
	var fullDate = new Date();
	myDate.innerHTML=fullDate.toDateString();
}  // end displayDate function

	
/*xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx*/
	
	

	
	
	
	
	
	
	
	
	
	
	






