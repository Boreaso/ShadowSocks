# -*- coding: utf-8 -*-
import os
import re
import sys   
import urllib
import urllib2
import pickle
import base64
import cookielib
from sgmllib import SGMLParser  

class StatsParser(SGMLParser):  
    #重写SGMLParser模块中的reset函数，  
    def reset(self):  
        #调用原来的函数resert  
        SGMLParser.reset(self)  
        #数据存放的位置  
        self.p_data = []  
        self.p_lable = False 
        self.header_data = []
        self.header_label = False 
        #self.url = []  
    #查找的标签(start_ +　标签）表示查找的那个标签（参数是固定的）  
    def start_p(self,attrs):  
        #查找对象的标签里面的属性(此处用到了列表解析)  
        #result = [v for k,v in attrs if len(k) > 0]  
        #判断href是不是存在  
        #if result:  
        #    self.url.extend(result)  
        #    print(result)
        self.p_lable = True  
    #查找结束的标志  
    def end_p(self):  
        self.p_lable = False  
    def start_header(self,attrs):
    	self.header_label = True
    def end_header(self):
    	self.header_label = False
    #处理信息数据
    def handle_data(self,data):  
        #判断标签数不超找完毕  
        if self.p_lable:  
            data = data.strip()  
            number = re.findall(r"\d+\.?\d*",data)
            if len(number) > 0:
            	self.p_data.append(number) 
        if self.header_label:
        	data = data.strip()
        	number = re.findall(r"\d+\.?\d*",data)
        	if len(number) > 0:
        		self.header_data.append(number)

class SmartRedirectHandler(urllib2.HTTPRedirectHandler):
    RedURLs301 = []
    RedURLs302 = []

    def Getredurl301(self):
        return SmartRedirectHandler.RedURLs301
    
    def Getredurl302(self):
        return SmartRedirectHandler.RedURLs302

    def http_error_301(self, req, fp, code, msg, headers):
        if headers.has_key("Location"):
            SmartRedirectHandler.RedURLs301.append(headers["Location"])
        result = urllib2.HTTPRedirectHandler.http_error_301(
            self, req, fp, code, msg, headers)
        return result                                       

    def http_error_302(self, req, fp, code, msg, headers):
        if headers.has_key("Location"):
            SmartRedirectHandler.RedURLs302.append(headers["Location"])
        result = urllib2.HTTPRedirectHandler.http_error_302(
            self, req, fp, code, msg, headers)                                  
        return result 

    def redirect_request(self, req, fp, code, msg, hdrs, newurl):
        self.last_url = newurl
        print("hdrs:{0}".format(hdrs))
        print("newurl:{0}".format(newurl))
        if hdrs.has_key("Set-Cookie"):
        	http_headers["Cookie"] = hdrs["Set-Cookie"]
        	print("http_headers:{0}".format(http_headers))
        r = urllib2.HTTPRedirectHandler.redirect_request(
            self, req, fp, code, msg, http_headers, newurl)
        r.get_method = lambda : 'HEAD'
        return r

http_token_url = "https://hf23.tk/clientarea.php"
http_login_token = "fd2e7881c2711956d1bd5833f84452a490aeac90"
http_login_url = "https://hf23.tk/dologin.php"
http_login_params = "dXNlcm5hbWU9NjQ4Mzk1ODQ1JTQwcXEuY29tJnBhc3N3b3JkPXBsZjE5OTMwMzE4"
http_query_url = "https://hf23.tk/clientarea.php?action=productdetails&id=1568"
http_headers = {"Cookie":"WHMCSliVxabgzLxTi=4iptp84u84759vm9ujh15lher4"}

def get_login_token():
	request = urllib2.Request(http_token_url)
	opener = urllib2.build_opener(SmartRedirectHandler)
	response = urllib2.urlopen(request)
	html = response.read().decode("utf-8").encode(sys.getfilesystemencoding())
	return re.search(r"(?<={0}).*?(?={1})".format("csrfToken = '","'"), html).group()

def login_for_cookie():
	"""登录以获取Cookie"""
	request = urllib2.Request(http_login_url)
	cj = cookielib.CookieJar()
	opener = urllib2.build_opener(urllib2.HTTPCookieProcessor(cj))
	response = opener.open(request, base64.b64decode(http_login_params))
	cookie_content = ""
	for c in cj:
	    cookie_content += c.name + "=" + c.value
	global http_headers
	http_headers["Cookie"] = cookie_content

def parse_stats_from_doc(doc):
	"""解析网页内容，返回数据统计字典形如：
	{
	'MonthTotal':1234,
	'MonthUsed':1234,
	'MonthUpload':24323,
	'MonthDownload':23234
	}
	"""
	parser = StatsParser()
	parser.feed(doc)
	print(parser.p_data)
	print(parser.header_data)
	dictionary = {
	'MonthTotal':parser.header_data[0],
	'MonthUsed':parser.p_data[0],
	'MonthUpload':parser.p_data[1],
	'MonthDownload':parser.p_data[2]}
	parser.close()
	return dictionary

def query_stats_html():
	"""请求页面数据"""
	request = urllib2.Request(url=http_query_url,headers=http_headers)
	print("start query stats...")
	response = urllib2.urlopen(request)
	html = response.read().decode("utf-8").encode(sys.getfilesystemencoding())
	return html

def pickle_load(filename):  
    ''' 
    调用pickle的load方法读入对象 
    @param filename 文件名 
    @return None-文件为空；否则-返回存入的对象 
    '''
    if not os.path.exists(filename):
    	open(filename,'wb').close()
    with open(filename, 'rb') as input_file:
    	try:
    		return pickle.load(input_file)
    	except EOFError,ex:
    		return None

def pickle_save(filename, obj):
	''' 
	调用pickle的dump方法导出对象
	@param filename 文件名
	@param obj 对象 
	''' 
	with open(filename, 'wb') as output_file:
		try:
			pickle.dump(obj, output_file)
		except Exception,ex:
			print("pickle_save error:{0}".format(ex))

def get_stats_by_http():
	'''获得数据统计''' 
	global http_headers
	
	getback = pickle_load('pydata.pkl')
	if not getback is None:
		http_headers = getback

	html = query_stats_html()
	result_dict = {}
	try:
		result_dict = parse_stats_from_doc(html)
	except:
		print("start login...")
		login_for_cookie()
		html = query_stats_html()
		result_dict = parse_stats_from_doc(html)

	pickle_save('pydata.pkl', http_headers)
	return result_dict