 //this model convert a datetime string to a style such as 
//yyyy/mm/dd or xx:xx:xx (am pm) datetime string  
function cdate(str)                
{
var a, b, c,  str2;
var posdate,postime;                //to post to position of "/" or ":"
var lenth; 
var strtemp;                        //temp string
var cdate;
lenth = str.length;
strtemp = str;
posdate = strtemp.indexOf("/");
postime=strtemp.indexOf(":");
if (postime!=-1) {cdate=covtime(strtemp); return cdate;}                   //to goto do with time type. 
//do with date type
//alert(strtemp);
if (posdate!=-1) {cdate=covdate(strtemp);return cdate;}
return "NULL";
}


//this model is convert date type to yyyy/mm/dd style
function covdate(str)
{
var strone,strtwo,strthree;//these varants part str into three string parts
var str2;
var posdate;
var lenth; 
var strtemp;                             //temp string
var intone,inttwo,intthree ;                 //these varants part str into three integer parts
var restr;                                //return value
lenth = str.length;
strtemp = str;
posdate = strtemp.indexOf("/");
strone = str.substring(0,posdate);
strtemp = strtemp.substring(posdate+1, lenth );
lenth = strtemp.length;
posdate = strtemp.indexOf("/");
if (posdate == -1) {
//to convert such as xx/xx style the function is cdatetwopart
intone = depparseInt(strone);
if (isnumeric(strone) == false)
{
return "NULL";
}
strtwo = strtemp.substring(posdate+1, lenth);
inttwo = depparseInt(strtwo);
if (isnumeric(strtwo) == false)
{
return "NULL";
}
restr = cdatetwopart(intone, inttwo);

pos=restr.lastIndexOf("/");
strtemp = restr.substring(0,pos);
strone = restr.substring(pos + 1,restr.length);
if (strone.length < 2) 
strone = "0" + strone;
pos = strtemp.lastIndexOf("/");
str2 = strtemp.substring(0,pos);
strtwo = strtemp.substring(pos + 1,strtemp.length);
if (strtwo.length < 2)
strtwo = "0" + strtwo;
restr=str2 + "/" + strtwo + "/" + strone;

return restr;
}
//exist three parts
strtwo = strtemp.substring(0, posdate);
if (isnumeric(strtwo) == false)
{
return "NULL";
}
strthree = strtemp.substring(posdate+1, lenth);
intone = depparseInt(strone);
inttwo = depparseInt(strtwo);
if (isnumeric(strthree) == false)
{
return "NULL";
}
intthree = depparseInt(strthree);

restr = cdatethreepart(intone,inttwo,intthree);         //call cdatethreepart to convert xx/xx/xx three parts

pos=restr.lastIndexOf("/");
strtemp = restr.substring(0,pos);
strone = restr.substring(pos + 1,restr.length);
if (strone.length < 2) 
strone = "0" + strone;
pos = strtemp.lastIndexOf("/");
str2 = strtemp.substring(0,pos);
strtwo = strtemp.substring(pos + 1,strtemp.length);
if (strtwo.length < 2)
strtwo = "0" + strtwo;
restr=str2 + "/" + strtwo + "/" + strone;

return restr;
}


function cdatethreepart(intone,inttwo,intthree)
{
var year;              //the varant value to goto diffrent functions
var i ;
var restr;
year = 0;
i = 0;
//if part one like year to make year
//if year>31 and year <100 add 1900 in front
if (intone > 31||intone==0)
{
year = intone;
if (intone < 100) {
	year = 1900 + intone;}
if(intone ==0){
	year = 2000;}
i = 1;
}
if (inttwo > 31||inttwo==0) {
year = inttwo;
if (inttwo < 100) {
	year = 1900 + inttwo;}
if(inttwo ==0){
	year = 2000;}
i = 2;
}
if (intthree > 31||intthree==0) {
year = intthree;
if (intthree < 100) {
	year = 1900 + intthree;}
if(intthree==0){
	year = 2000;}
i = 3;
}

if (i==1) {                          //the first part is year;
restr=partoneisyear(year, inttwo, intthree);}
if (i==2) {                          //the part two is year;
restr=parttwoisyear(intone, year, intthree);}
if (i==3) {                          //the part three is year;
restr=partthreeisyear(intone, inttwo, year);}
if (i==0) {                          //no part is year;
restr=nopartisyear(intone, inttwo, intthree);}
return restr;
}
//this function is do with part one is year
function partoneisyear(a, b , c )
{var restr;
if (b > 12) 
{
restr = "" + a + "" + "/" + "" + c + "" + "/" + "" + b + "";
}
  else{                            //such as if(XX==) words is used to control user input 0 like 1/1/0
                                  // it will be converted to like 1/1/1
if(c == 0) 
restr = "" + a + "" + "/" + "" + b + "" + "/" + "" + 1 + "";
else
restr = "" + a + "" + "/" + "" + b + "" + "/" + "" + c + "";
  }
return restr;
}


//this function do with part two is year
function parttwoisyear(a , b, c){ 
var restr;
if (a > 12) {
restr = "" + b + "" + "/" + "" + c + "" + "/" + "" + a + "";
}  else
{if (c == 0)
restr = "" + b + "" + "/" + "" + a + "" + "/" + "" + 1 + "";
else
restr = "" + b + "" + "/" + "" + a + "" + "/" + "" + c + "";
  }
return restr;
}
//this function do with part three is year
function partthreeisyear(a, b, c){
var restr;
if (a > 12) {
restr = "" + c + "" + "/" + "" + b + "" + "/" + "" + a + "";
}
  else
  {if (b == 0 )
  restr = "" + c + "" + "/" + "" + a + "" + "/" + "" + 1 + "";
  else
  restr = "" + c + "" + "/" + "" + a + "" + "/" + "" + b + "";
  }
return restr;
}
//this function do with cant confirm whith is year
function nopartisyear(a , b, c ){
var restr;
if (a > 12 && c > 12) {
if (c < 30) {
restr = "" + (c  + 2000) + "" + "/" + "" + b + "" + "/" + "" + a + "";
}
else
{
restr = "" + (c + 1900) + "" + "/" + "" + b + "" + "/" + "" + a + "";
}
return restr;
}
if (a > 12 && b > 12) {
if (a < 30) {
restr = "" + (a + 2000) + "" + "/" + "" + c + "" + "/" + "" + b + "";}
else{
restr = "" + (a + 1900) + "" + "/" + "" + c + "" + "/" + "" + b + "";
}
return restr;
}
if (c > 12 && b > 12) {
if (c < 30) {
restr = "" + (c + 2000) + "" + "/" + "" + a + "" + "/" + "" + b + "";}
else{
restr = "" + (c + 1900) + "" + "/" + "" + a + "" + "/" + "" + b + "";
}
return restr;
}
if(a>12){
if (a < 30) {
if(b == 0)
restr = "" + (a + 2000) + "" + "/" + "" + c + "" + "/" + "" + 1 + "";
else
restr = "" + (a + 2000) + "" + "/" + "" + c + "" + "/" + "" + b + "";}
else{
if (b == 0)
restr = "" + (a + 1900) + "" + "/" + "" + c + "" + "/" + "" + 1 + "";
else
restr = "" + (a + 1900) + "" + "/" + "" + c + "" + "/" + "" + b + "";
}
return restr;
}
if(c>12){
if (c < 30) {
if (b == 0)
restr = "" + (c + 2000) + "" + "/" + "" + a + "" + "/" + "" + 1 + "";
else
restr = "" + (c + 2000) + "" + "/" + "" + a + "" + "/" + "" + b + "";}
else{
if (b == 0)
restr = "" + (c + 1900) + "" + "/" + "" + a + "" + "/" + "" + 1 + "";
else
restr = "" + (c + 1900) + "" + "/" + "" + a + "" + "/" + "" + b + "";
}
return restr;
}
if(b>12){
if (b < 30) {
if (a == 0)
restr = "" + (b + 2000) + "" + "/" + "" + c + "" + "/" + "" + a + "";
else
restr = "" + (b + 2000) + "" + "/" + "" + c + "" + "/" + "" + a + "";}
else{
if (a == 0)
restr = "" + (b + 1900) + "" + "/" + "" + c + "" + "/" + "" + a + "";
else
restr = "" + (b + 1900) + "" + "/" + "" + c + "" + "/" + "" + a + "";
}
return restr;
}
//if(c == 0)
//restr = "" + (a + 2000) + "" + "/" + "" + b + "" + "/" + "" + 1 + "";
//else
//if(b == 0)
//restr = "" + (b + 2000) + "" + "/" + "" + a + "" + "/" + "" + c + "";
//else
//restr = "" + (a + 2000) + "" + "/" + "" + b + "" + "/" + "" + c + "";


if(c == 0)
restr = "" + (c + 2000) + "" + "/" + "" + a + "" + "/" + "" + b + "";
else
if(a == 0)
restr = "" + (a + 2000) + "" + "/" + "" + b + "" + "/" + "" + c + ""   ;
else
restr = "" + (c + 2000) + "" + "/" + "" + a + "" + "/" + "" + b + "";

return restr;
}
function cdatetwopart(a,b ) {
var  dateD=new Date;
var restr;
if (a > 30) {
if (a < 100) {
restr = "" + (1900 + a) + "" + "/" + "" + b + "" + "/" + "1";
}
else
{
restr = "" + a + "" + "/" + "" + b + "" + "/" + "1";
}
return restr;
}
// a<=30
if (b > 31) {
if (b < 100) {
if (a > 12) 
restr = "" + (1900 + b) + "" + "/" + "" + "1" + "" + "/" + a;
else
restr = "" + (1900 + b) + "" + "/" + "" + a + "" + "/" + "1";}
else
{
if (a > 12 )
restr = "" + b + "" + "/" + "" + "1" + "" + "/" + a;
else
restr = "" + b + "" + "/" + "" + a + "" + "/" + "1";
}

return restr;
}
//b<=31 ;a<=30;
if (a <= 12) {
if (a == 0) {
restr = "" + 2000 + "" + "/" + "" + b + "" + "/" + "1";
return restr;
}
if (b == 0) {
restr = "" + 2000 + "" + "/" + "" + a + "" + "/" + "1";
return restr;
}
restr = "19" + dateD.getYear() + "" + "/" + "" + a + "" + "/" + "" + b + "";

if (isdate(restr) == false) {
restr = "" + (1900 + b) + "" + "/" + "" + a + "" + "/" + "1";
}
return restr;
}
restr = "" + (1900 + a) + "" + "/" + "" + b + "" + "/" + "1";
return restr;
}


//this function to convert time type return string is like xx:xx:xx (pm,am) or xx:xx (pm,am)
function covtime(str){
var restr="";                       //init return string
var pos=str.indexOf(":");
var tempfirst=str.substring(0,pos);
//if it a single bit then add 0 in front
if (depparseInt(tempfirst)<10) 
 restr=restr + "0" + depparseInt(tempfirst) ;
else 
 restr=depparseInt(tempfirst);
pos++;
var templast=str.substring(pos,str.length);
pos=templast.indexOf(":");
if (pos!=-1) {
//like xx:xx:xx
tempfirst=templast.substring(0,pos);
if (depparseInt(tempfirst)<10) restr=restr + ":" + "0" + depparseInt(tempfirst);
 else restr=restr + ":" + depparseInt(tempfirst);
}
pos++;
templast=templast.substring(pos, templast.length);
if (trim(templast.length)>2)
{                                       //exist 'am' or 'pm'
tempfirst=templast.substring(0,2);
if (isNaN(parseInt(tempfirst))==false) 
{
if (depparseInt(tempfirst)<10) 
restr=restr + ":" + "0" + depparseInt(tempfirst);
 else 
 restr=restr + ":" + depparseInt(tempfirst);
 restr=restr+templast.substring(2,templast.length);
 }
else {
tempfirst=templast.substring(0,1);
if (depparseInt(tempfirst)<10) 
restr=restr + ":" + "0" + depparseInt(tempfirst);
 else 
 restr=restr + ":" + depparseInt(tempfirst); 
 restr=restr+templast.substring(1,templast.length);
 } 
}
else {
tempfirst=templast;
if (depparseInt(tempfirst)<10) 
restr=restr + ":" + "0" + depparseInt(tempfirst);
 else 
 restr=restr + ":" + depparseInt(tempfirst);
 }
 
 return restr;
}


 //this function is used confirm whether string is a datetime type
//if it is return true else return false
//this function is not support that style such as dev 23 1998 12:00:00
function isdate(str)
{var i;                    //this tag to tell pm and am 
 var posdate;            //the varant use to post the date position
 var lenth;
 var postime;           //the varant use to post the time position
 var strtemp=str;
 lenth=strtemp.length;
 posdate=strtemp.indexOf("/");                   //post date type
 postime=strtemp.indexOf(":");                   //post time type
 if ((posdate==-1) && (postime==-1)) { return false;}
 if ((posdate!=-1) && (postime==-1))
 {                    //it is a date type
  var strfirst=strtemp.substring(0,posdate);
 if (isnumeric(strfirst)==false)
 return false;
 strtemp=strtemp.substring(posdate+1,lenth);
 posdate=strtemp.indexOf("/");
 if (posdate==-1) 
 {                   //do with two parts style such as xx/xx
 var strmiddle=strtemp;
 if (isnumeric(strmiddle)==false)
 return false;
 else
 return twopart(depparseInt(strfirst),depparseInt(strmiddle));
 }
 //do with three parts style such as xx/xx/xx
 lenth=strtemp.length;
 strmiddle=strtemp.substring(0,posdate);
 if (isnumeric(strmiddle)==false) return false;
 var strlast=strtemp.substring(posdate+1,lenth);
 if (isnumeric(strlast)==false) return false;
 else
 {

 return threepartdo(depparseInt(strfirst),depparseInt(strmiddle),depparseInt(strlast)) ;
 }
}
//it is a time type
if ((postime!=-1) && (posdate==-1)) 
{ var strfirst=strtemp.substring(0,postime);
  if (isnumeric(strfirst)==false) return false;
  if (parseInt(strfirst)>24 || parseInt(strfirst)<0) return false;          //hour
  strtemp=strtemp.substring(postime+1,lenth);
  postime=strtemp.indexOf(":");
  if (postime!=-1) {
  //do with three parts such as xx:xx:xx (pm.am)
  strfirst=strtemp.substring(0,postime);
  if (isnumeric(strfirst)==false) return false;
  if (depparseInt(strfirst)>60 || depparseInt(strfirst)<0) return false;      //minunts
  strtemp=strtemp.substring(postime+1,lenth);
    }
  var temp=strtemp;
  if (isnumeric(temp)==true)
  {if (depparseInt(temp)<0 || depparseInt(temp)>60) return false               //seconds
    else return true;}
  var tag=0;
  if (temp.indexOf("am")!=-1) tag=1;
  if (temp.indexOf("Am")!=-1) tag=2;
  if (temp.indexOf("AM")!=-1) tag=3;
  if (temp.indexOf("aM")!=-1) tag=4;
  if (temp.indexOf("PM")!=-1) tag=5;
  if (temp.indexOf("Pm")!=-1) tag=6;
  if (temp.indexOf("pM")!=-1) tag=7;
  if (temp.indexOf("pm")!=-1) tag=8;
  if (tag!=0) {
  if (isnumeric(trim(temp.substring(0,temp.length-2)))==false) return false;
  if ((parseInt(trim(strfirst))>12) || (parseInt(trim(strfirst))<0))
               return false;}
  if (isNaN(parseInt(temp))==true) return false;
  if ((parseInt(temp)>60) || (parseInt(temp)<0)) return false;
  return true;
  }
}

function threepart(year,month,day)
{
 //alert(year);alert(month);alert(day);
 if ((year<=100)||(year<=0)) return false;
 if ((month>12)||(month<=0)) return false;
 if ((day>31)||(day<=0)) return false;
 //do with special years and months
 if (((month==2)||(month==4)||(month==6)||(month==9)||(month==11))&&(day>30)) return false;
 if ((month==2)&&(day>29))  return false;
 if (!((((year/4)==depparseInt(year/4))&&((year/100)!=depparseInt(year/100)))||((year/400)==depparseInt(year/400)))&&(month>28)) return false;
 if (year<1753) return false;
 return true;
}
function threepart1(year,month,day)
{
 if (threepart(year,month,day)==false) {
  if ((year<100)&&(year>30)) {year=year+1900;return threepart(year,month,day);} else if(year<=30) {year=year+2000;return threepart(year,month,day);}
  if ((month<100)&&(month>30)) {month=month+1900;return threepart(month,year,day);} else if(month<=30) {month=month+2000;return threepart(month,year,day);}
  if ((day<100)&&(day>30)) {day=day+1900;return threepart(day,year,month);} else if(day<=30) {day=day+2000;return threepart(day,year,month);}
  }
  return true;
}  
//this function do with three parts date type
function threepartdo(year,month,day)
{                    //distinguish 12 conditions
 //threepart function only do with the style like yyy/mm/dd or yyyy/mm/dd
 //threepart1 function combined threepart parameters
 if (threepart(year,month,day)==true) return true;
 if (threepart1(year,month,day)==true) return true;
 if (threepart(month,day,year)==true) return true;
 if (threepart1(month,day,year)==true) return true; 
 if (threepart(day,year,month)==true) return true;
 if (threepart1(day,year,month)==true) return true;
 if (threepart(month,year,day)==true) return true;
 if (threepart1(month,day,year)==true) return true; 
 if (threepart(year,day,month)==true) return true;
 if (threepart1(year,day,month)==true) return true; 
 if (threepart(day,month,year)==true) return true;
 if (threepart1(day,month,year)==true) return true;
 return false;
 }
 //this function do with date type such as xx/xx
function twopart(a,b)
{var  dateD=new Date;
// alert(a);alert(b);
 if ((threepartdo("19"+dateD.getYear(),a,b))==true)
 {return true;}
 if (a>=30) {
 if (threepartdo(a+1900,b,1)==true)
 return true;}
 if (a<30) {
 if (threepartdo(a+2000,b,1)==true)
 return true;
 }
 if(threepartdo(a,b,1)==true) return true; 
return false;
}

function cint(str)
{
  var tag=0;                       //this varaent illuslation if exist E or e
  var tag1=0;                      //this varaent illuslation if exist "-"
  var pos1=0;//make position of the "-"
  var subcint2
  var pos=str.indexOf("e");           //this varaent is posed E or e
  if (pos==-1) 
  { pos=str.indexOf("E");
    if (pos!=-1) tag=1;             //if tag=1 exist E ot e
  }
  else tag=1; 
  //the following is convert style which exist E or e 
  if (tag==1) 
  {
    var subcint1=str.substring(0,pos);
    pos++;
    var temp=str.substring(pos,str.length);
    pos1=temp.indexOf("-");
    if (pos1!=-1) 
    tag1=1;                 //tag1 taged if str include "-"
    pos1=str.substring(pos,str.substring.length).indexOf("+");
    if (pos1!=-1)
    pos++;
    if (tag1==0) //not exist "-" 
    { subcint2=str.substring(pos,str.length);
      if (isNaN(parseInt(subcint2))) return "cant convert";
     subcint2=depparseInt(subcint2);
     total=subcint1;
     while (subcint2!=0)
     {total=total*10; subcint2--;             //convert
     }
     return parseInt(total);
    }
    if(tag1==1)                  //exist "-"
    {pos++ ; subcint2=str.substring(pos,str.length);
     if (isNaN(parseInt(subcint2))) return "cant convert";
     subcint2=depparseInt(subcint2);
     total=subcint1;
     while (subcint2!=0)
     {total=total*0.1;subcint2--;//convert
     }
     return parseInt(total);
    }  
  }
   return depparseInt(str);    
     
}   
//this function is used to tell whether str is numeric. 
function isnumeric(str)
{
   var chrC;
   var intC;
   var intLen;
   var intI;
   var token=0;//tag the number of "."
   var token1=0;//tag the number of "e" or "E"
   str=Cstr(str);
   str=trim(str);
   intLen=str.length;
   intI=0;
   chrC=str.substring(intI,intI+1);//get the first char
   if ((chrC.indexOf("+")!=-1)||(chrC.indexOf("-")!=-1)) intI++;
   chrC=str.substring(intI,intI+1);//remorve first + or -  
   if (isNaN(parseInt(chrC)) && (chrC.indexOf(".")==-1) && (chrC.indexOf("E")==-1) && (chrC.indexOf("e")==-1)) return false;
  //first char is E or e
   if ((chrC.indexOf("e")!=-1) || (chrC.indexOf("E")!=-1))
     {
	return false;
        intI++;
        if (intI<intLen)
        {
          chrC=str.substring(intI,intI+1);
          if (isNaN(parseInt(chrC)) && (chrC.indexOf("+")==-1) && (chrC.indexOf("-")==-1)) return false;
          if ((chrC.indexOf("+")!=-1) || (chrC.indexOf("-")==-1))
          {
            intI++;
          }  
          for(;intI<intLen;intI++)
          {
            chrC=str.substring(intI,intI+1);
	        if(isNaN(parseInt(chrC)))
	        {
	          return false;
            }
          }
       }
        return true;
      }
   //first char is not a E or e
   intI++;
   for(;intI<intLen;intI++)
   {
     chrC=str.substring(intI,intI+1);
	 if((isNaN(parseInt(chrC))) && (chrC.indexOf(".")==-1) && (chrC.indexOf("e")==-1) && (chrC.indexOf("E")==-1))
	 {
	   return false;
     }
     //exist "."
     if((isNaN(parseInt(chrC))) && (chrC.indexOf(".")!=-1))
     {
       intI++;token++;
       if (token!=1) return false;
     }
     if((chrC.indexOf("e")!=-1)|| (chrC.indexOf("E")!=-1))
     {
       intI++;token1++;
       if (token1!=1) return false;
     }  
   }     
	 return true;
}
//depparseInt be used to convert chat type to int type
//because praseInt cant convert such as '01' to 0 instead 1
function depparseInt(str)
{
 var a=parseInt(str);
 var pos=0;
 str=Cstr(str);
 var str1=str.substring(pos,pos+1);
 var lenth;
 if (str1.indexOf("-")!=-1)
 {pos++;a=parseInt(str.substring(pos,str.length)); var tag=1}
 
 while (a==0)
 {  //remove 0 char in front of the str
   lenth=str.length;
   if (isNaN(parseInt(str.substring(pos,pos+1)))) return 0;
   str=str.substring(pos+1,lenth);
   a=parseInt(str);
   pos++;
 }
 if (isNaN(a)) return 0;
 if (tag==1) a=parseInt('-'+Cstr(a));
 return a;
}
//4.取消字符串前後的空格
function Cstr(inp)
{
  return(""+inp+"");
}
function trim(inString)
{
   var l,i,g,t,r;  
    inString=Cstr(inString);
    l=inString.length;
    t=inString;
   for(i=0;i<l;i++)
   {
       g=inString.substring(i,i+1);
       if(g==" ")
       {
          t=inString.substring(i+1,l);
        }
       else
       {
         break;;
       }
    }
   r=t;
   l=t.length;
   //Delete the spaces back
   for(i=l;i>0;i--)
   {
      g=t.substring(i,i-1);
      if(g==" ")
      {
        r=t.substring(i-1,0);
      }
      else
     {
        break;
     }
   }
   return(r);
}
function replace(target,oldTerm,newTerm,caseSens,wordOnly) 
{ var wk ;
  var ind = 0; 
  var next = 0; 
  wk=Cstr(target); 
  if (!caseSens) {
  oldTerm = oldTerm.toLowerCase();    
  wk = target.toLowerCase();  }
  while ((ind = wk.indexOf(oldTerm,next)) >= 0) 
  {    if (wordOnly) {
      var before = ind - 1;     
	   var after = ind + oldTerm.length;
      if (!(space(wk.charAt(before)) && space(wk.charAt(after)))) {
        next = ind + oldTerm.length;     
		   continue;      }    }
 target = target.substring(0,ind) + newTerm + target.substring(ind+oldTerm.length,target.length);
 wk = wk.substring(0,ind) + newTerm + wk.substring(ind+oldTerm.length,wk.length);
 next = ind + newTerm.length;    
if (next >= wk.length) { break; }
  }
  return target;
  }

function Rep1(str,len)
{var str1;
 str1=str;
 str1=replace(str1,"'","`",1,0);
 str1=replace(str1,'"',"`",1,0);
 str1=replace(str1,"<","(",1,0);
 str1=replace(str1,">",")",1,0);
 str1=deletechar(str1,len);
 return str1;
}

function Rep1(str)
{var str1;
 str1=str;
 str1=replace(str1,"'","`",1,0);
 str1=replace(str1,'"',"`",1,0);
 str1=replace(str1,"<","(",1,0);
 str1=replace(str1,">",")",1,0);
 return str1;
}


function deletechar(str,len){
var lenth;
lenth = 0;
var i = 0;
if (isNaN(len)) return str;
while ((i < str.length) && (i < len) && (lenth < len))
{

	
	if (escape(str.substring(i,i + 1)).length < 4)
		lenth = lenth + 1;
	else
		lenth = lenth + 2;
	i ++;
}

if (lenth > len)
{
	if (escape(str.substring(i - 1,i)).length > 4)
		i --;
}
return str.substring(0, i);
}

function manytring(num,chr)
{
   var i;
   chr=Cstr(chr);
   var strR;
   strR=chr;
   for(i=1;i<num;i++)
	{    
	      strR=strR+chr;
     }
	 strR=Cstr(strR);

   return strR;
}
function getfilename(str)
{ var q=trim(str).lastIndexOf("\\");
  if (q!=-1) str=trim(str).substring(q+1,trim(str).length);
  var p=trim(str).lastIndexOf(".");
  if (p==-1) {return str;}
  else
  {
  var leng=trim(str).length;
  var retstr=str.substring(0,p);
  return retstr;}
}

function getfileprop(str)
{ var p=trim(str).lastIndexOf(".");
 
  if (p==-1) return "";
  else
  {
  var leng=trim(str).length;
  var retstr=str.substring(p,leng);
  return retstr;}
}
function isfloat(str)
{
var loctionpoint=trim(str).lastIndexOf(".");
if (loctionpoint!=-1){
    if(isnumeric(str)){
       return true;}
   }
else
    return false;
} 

function isint(str)
{
	var bflag=true
	var nLen=str.length
	for(i=0;i<nLen;i++)
	{
		if(str.charAt(i)<'0'||str.charAt(i)>'9')
			bflag=false
	}
	return bflag
}

function Rep2(str)
{
	var str1;
 	str1=str;
 	str1=replace(str1,"'","`",1,0);
 	str1=replace(str1,'"','``',1,0);
 	str1=replace(str1,"<","&lt",1,0);
 	str1=replace(str1,">","&gt",1,0);
 	return str1;
}

function InputRep(str)
{
	var str1;
 	str1=str;
 	str1=replace(str1,"'","`",1,0);
 	str1=replace(str1,'"','``',1,0);

 	return str1;
}

function SelectText(txt)
{
	txt.focus();
	txt.select();
}

