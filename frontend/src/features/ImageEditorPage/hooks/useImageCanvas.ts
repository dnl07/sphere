import { useEffect, useRef, useState } from "react"

export const useImageCanvas = (file: File | null) => {
    const canvasRef = useRef<HTMLCanvasElement>(document.createElement("canvas"))
    const [previewUrl, setPreviewUrl] = useState<string | null>(null)

    useEffect(() => {
        if (!file) return

        applyBlob(file)
    }, [file])

    const updatePreview = () => {
        setPreviewUrl(canvasRef.current.toDataURL())
    }

    const applyBlob = (blob: Blob) => {
        const image = new Image()
        const url = URL.createObjectURL(blob)
        image.onload = () => {
            const canvas = canvasRef.current
            canvas.width = image.width
            canvas.height = image.height
            canvas.getContext("2d")!.drawImage(image, 0, 0)
            URL.revokeObjectURL(url)
            updatePreview()
        }
        image.src = url
    }

    const toFile = (filename: string, filterString?: string): Promise<File> => {
        const offscreen = document.createElement("canvas")
        const src = canvasRef.current
        offscreen.width = src.width
        offscreen.height = src.height
        const ctx = offscreen.getContext("2d")!

        if (filterString) {
            ctx.filter = filterString
        }

        ctx.drawImage(src, 0, 0)
        return new Promise((res) => {
            offscreen.toBlob((blob) => res(new File([blob!], filename, { type: "image/png" })))
        })
    }

    return { previewUrl, applyBlob, toFile }
}
