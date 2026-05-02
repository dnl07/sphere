export const convertToPng = async (file: File, maxSize: number = 1280): Promise<File> => {
    return new Promise((resolve) => {
        const image = new Image();
        const url = URL.createObjectURL(file);
        
        image.onload = () => {
            const ratio = Math.min(maxSize / image.width, maxSize / image.height, 1)
            const width = Math.round(image.width * ratio);
            const height = Math.round(image.height * ratio);

            const canvas = document.createElement("canvas");
            canvas.width = width;
            canvas.height = height;

            const context = canvas.getContext("2d");
            context?.drawImage(image, 0, 0, width, height);

            canvas.toBlob((blob) => {
                URL.revokeObjectURL(url);
                const converted = new File([blob!], file.name.replace(/\.\w+$/, ".png"), {
                    type: "image/png"
                });
                resolve(converted);
            }, "image/png");
        }

        image.src = url;
    });
}