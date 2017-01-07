insert into Inventory
(sku,variation, title, short_title,Cost,Supplier,image_url, main_image_url,weight, packaged_weight,bubblewrap,
 packaging,ebayitemid,ebayitemhistoryid,asin, upc,location,active,last_modified)
select ttb_sku, variation, title, short_title, Cost,Supplier,image_url, main_image_url,
       weight,packaged_weight,bubblewrap, packaging,ebayitemid,null,null, manufacturer_sku,location,active,last_modified
  from tty_storagelocation
 where active=1     
 