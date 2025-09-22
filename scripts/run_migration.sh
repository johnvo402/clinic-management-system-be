#!/bin/bash

# Lấy ngày tháng năm giờ phút giây hiện tại
current_datetime=$(date +"%Y%m%d%H%M%S")

# Tên migration
migration_name="${current_datetime}_Migration"

# Đường dẫn project
infrastructure_path="src/CMS_BE.Infrastructure"
api_path="src/CMS_BE.Presentation"

echo "Running migration: $migration_name"

dotnet ef migrations add "$migration_name" --project "$infrastructure_path" --startup-project "$api_path" -o Data/Migrations

if [ $? -eq 0 ]; then
    echo "Migration completed successfully."
else
    echo "Migration failed."
    exit 1
fi
