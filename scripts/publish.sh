#!/bin/bash

echo "Starting monolith publication..."

publish_monolith() {
    local service_root="src"
    local csproj_path="CMS_BE.Presentation/CMS_BE.Presentation.csproj"

    echo "--------------------------------------"
    echo "Publishing..."

    local output_path="./app/publish"

    cd "$service_root" || { echo "❌ Failed to cd into $service_root"; exit 1; }

    # Publish monolith
    dotnet publish "$csproj_path" -c Release -o "$output_path"

    if [ $? -ne 0 ]; then
        echo "❌ Failed to publish."
        exit 1
    fi

    echo "✅ published successfully."
    cd - > /dev/null
}

publish_monolith

echo "🎉 Monolith published successfully!"
