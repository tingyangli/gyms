# -*- codeing = utf-8 -*-
from bs4 import BeautifulSoup  # 网页解析，获取数据
import re  # 正则表达式，进行文字匹配`
import urllib.request, urllib.error  # 制定URL，获取网页数据
import xlwt  # 进行excel操作
import pymysql

#import sqlite3  # 进行SQLite数据库操作

findaddr = re.compile(r'地址：</span></div> <div data-v-c47467c8=""><div data-v-c47467c8=""><a data-v-c47467c8="" href="javascript:void\(0\)">(.*?)</a>')
findName = re.compile(r'<span data-v-c47467c8="" class="headline">(.*?)</span>')
findPart = re.compile(r'部门：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
finddistribute = re.compile(r'分布特征：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
findlocate = re.compile(r'位置特征：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
findlandform = re.compile(r'地形特征：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
findgeograph = re.compile(r'地理空间关系：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
findage = re.compile(r'年代：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
findera = re.compile(r'时代：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
findarea = re.compile(r'占地面积：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
findstatus = re.compile(r'遗存现状：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
findprotect = re.compile(r'保护措施：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
finduse = re.compile(r'现状用途：</div> <div data-v-11e25c89="" class="right">(.*?)</div>')
findimg = re.compile(r'img data-v-c47467c8="" fit="cover" class="cover" src="(.*?)">')


def main():
    baseurl = "http://192.168.174.128:8080/"  #要爬取的网页链接
    # 1.爬取网页
    datalist = getData(baseurl)
    savepath = "工业遗产.xls"    #当前目录新建XLS，存储进去
    # dbpath = "movie.db"              #当前目录新建数据库，存储进去
    # 3.保存数据
    #saveData(datalist, savepath)      #2种存储方式可以只选择一种
    saveData2DB(datalist)



# 爬取网页
def getData(baseurl):
    datalist = []
    for i in range(1, 205):
        url = baseurl + str(i) + ".html"
        # print(url)
        html = askURL(url)  # 保存获取到的网页源码
        # soup = BeautifulSoup(html, "html.parser")
        data = []
        addr = findaddr.search(html)
        name = findName.search(html)
        part = findPart.search(html)
        distribute = finddistribute.search(html)
        locate = findlocate.search(html)
        landform = findlandform.search(html)
        geograph = findgeograph.search(html)
        age = findage.search(html)
        era = findera.search(html)
        area = findarea.search(html)
        status = findstatus.search(html)
        protect = findprotect.search(html)
        use = finduse.search(html)
        # imgurl = findimg.search(html).group(1)

        if (name is None):
            data.append(None)
        else:
            data.append(name.group(1))
        if (addr is None):
            data.append(None)
        else:
            data.append(addr.group(1))
        if (part is None):
            data.append(None)
        else:
            data.append(part.group(1))
        if (distribute is None):
            data.append(None)
        else:
            data.append(distribute.group(1))
        if (locate is None):
            data.append(None)
        else:
            data.append(locate.group(1))
        if (landform is None):
            data.append(None)
        else:
            data.append(landform.group(1))
        if (geograph is None):
            data.append(None)
        else:
            data.append(geograph.group(1))
        if (age is None):
            data.append(None)
        else:
            data.append(age.group(1))
        if (era is None):
            data.append(None)
        else:
            data.append(era.group(1))
        if (area is None):
            data.append(None)
        else:
            data.append(area.group(1))
        if (status is None):
            data.append(None)
        else:
            data.append(status.group(1))
        if (protect is None):
            data.append(None)
        else:
            data.append(protect.group(1))
        if (use is None):
            data.append(None)
        else:
            data.append(use.group(1))

        # f = open(str(i) + '.jpg', "wb")  # 打开文件
        # req = urllib.request.urlopen(imgurl)
        # buf = req.read()  # 读出文件
        # f.write(buf)  # 写入文件

        datalist.append(data)

    return datalist


# 得到指定一个URL的网页内容
def askURL(url):
    head = {  # 模拟浏览器头部信息，向豆瓣服务器发送消息
        "User-Agent": "Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 80.0.3987.122  Safari / 537.36"
    }
    # 用户代理，表示告诉豆瓣服务器，我们是什么类型的机器、浏览器（本质上是告诉浏览器，我们可以接收什么水平的文件内容）

    request = urllib.request.Request(url, headers=head)
    html = ""
    try:
        response = urllib.request.urlopen(request)
        html = response.read().decode("utf-8")
    except urllib.error.URLError as e:
        if hasattr(e, "code"):
            print(e.code)
        if hasattr(e, "reason"):
            print(e.reason)
    return html


# 保存数据到表格
def saveData(datalist, savepath):
    print("save.......")
    book = xlwt.Workbook(encoding="utf-8", style_compression=0)  # 创建workbook对象
    sheet = book.add_sheet('工业遗产', cell_overwrite_ok=True)  # 创建工作表
    col = ("名字", "地址", "部门", "分布特征", "位置特征", "地形特征", "地理空间关系", "年代", "时代", "占地面积", "遗存现状", "保护措施", "现状用途", "图片")
    for i in range(0, 14):
        sheet.write(0, i, col[i])  # 列名
    for i in range(0, 204):
        # print("第%d条" %(i+1))       # 输出语句，用来测试
        data = datalist[i]
        for j in range(0, 13):
            sheet.write(i+1, j, data[j])  # 数据
        # sheet.write(i+1, 13, str(i) + '.jpg')

    book.save(savepath)  # 保存


def saveData2DB(datalist):

    # 注意使用Binary()函数来指定存储的是二进制
    # cursor.execute("INSERT INTO demo_pic_repo SET touxiang_data= %s" % pymysql.Binary(img))
    for i in range(187, 205):
        fp = open(str(i) + ".jpg", 'rb')
        img = fp.read()
        fp.close()
        sql = "update info set picture = %s where name = %s"
        print(i)
        args = (img, datalist[i - 1][0])
        try:
            conn = pymysql.connect(host="localhost", user="root", password="20010306", database="INDUSTRIAL_HERITAGE",
                                   charset="utf8", connect_timeout=100, read_timeout=100)
            print("数据库连接成功")
        except pymysql.Error as e:
            print("数据库连接失败：" + str(e))

        cursor = conn.cursor()
        cursor.execute(sql, args)

        # 提交，不然无法保存新建或者修改的数据
        conn.commit()

        # 关闭游标
        cursor.close()
        # 关闭连接
        conn.close()



# def init_db(dbpath):
#     sql = '''
#         create table movie250(
#         id integer  primary  key autoincrement,
#         info_link text,
#         pic_link text,
#         cname varchar,
#         ename varchar ,
#         score numeric,
#         rated numeric,
#         instroduction text,
#         info text
#         )
#
#
#     '''  #创建数据表
#     conn = sqlite3.connect(dbpath)
#     cursor = conn.cursor()
#     cursor.execute(sql)
#     conn.commit()
#     conn.close()

# 保存数据到数据库







if __name__ == "__main__":  # 当程序执行时
    # 调用函数
     main()
    # init_db("movietest.db")
     print("爬取完毕！")

