#!/bin/bash
# Создаём имя файла с текущей датой
DATE=$(date +%Y-%m-%d_%H-%M)
FILE_NAME="shop_backup_$DATE.db"

# Копируем базу
cp shop.db $FILE_NAME

echo "Бекап создан: $FILE_NAME"
echo "Список файлов в папке:"
ls -l *.db
