import { useState } from "react";
import Card from "../../../../shared/components/layout/Card";
import Carousel from "../../../../shared/components/ui/Carousel";
import useImageFilters from "../../hooks/useImageFilters";
import { allEditorTools, allFilterTools } from "../../constants/tools";
import { isActionTool, isFilterTool, type FilterControlProps } from "../../constants/types";
import { useBackgroundRemover } from "../../../createItemPage/hooks/useBackgroundRemover";
import { useImageCanvas } from "../../hooks/useImageCanvas";
import { useNavigate } from "react-router";

type Props = {
    imageUrl: string | null;
    file: File | null;
}

const ImageEditor = ({ imageUrl, file}: Props) => {
    const navigate = useNavigate();
    const {previewUrl, applyBlob, toFile} = useImageCanvas(file);
    const {filters, filterString, updateFilter} = useImageFilters(allFilterTools);
    const  {processImage, loading} = useBackgroundRemover();

    // mobile
    const [activeKey, setActiveKey] = useState<string>("removal")
    const activeTool = allEditorTools.find(tool => tool.key === activeKey)

    const handleRemoveBackground = async () => {
        if (!file) return

        const canvasFile = await toFile(file?.name, filterString);
        if (!canvasFile) return

        const processedFile = await processImage(canvasFile)
        applyBlob(processedFile);
    }

    const renderControl = () => {
        if (!activeTool) return;

        if (isFilterTool(activeTool)) {
            return (
                activeTool.renderControl({
                    value: filters[activeTool.key],
                    onChange: (v) => updateFilter(activeTool.key, v),
                    tool: activeTool
                } as FilterControlProps))
        } else if (isActionTool(activeTool)) {
            return activeTool.renderControl({onAction: handleRemoveBackground})
        }
    }

    const onSave = async () => {
        if (!file) return;

        const finalFile = await toFile(file?.name, filterString);
        applyBlob(finalFile);

        navigate("/atelier/clothing", { state: {
            editedFile: finalFile
        }})
    }

    return (
        <div className="w-full flex flex-col items-center">
            <div className="w-full flex">
                <button 
                    className="bg-black text-white justify-end items-end py-1 px-4 mr-2 rounded-xl whitespace-nowrap cursor-pointer"
                    onClick={onSave}
                >
                    Apply
                </button>
            </div>
            {loading ?? <div>loading</div>}
            {imageUrl ? 
                <div className="w-full flex justify-center pb-35">
                    <img src={previewUrl ?? imageUrl} className="h-full object-contain" style={{ filter: `${filterString}`}}/>
                </div>
            :
                <div className="w-full h-full  flex justify-center items-center">
                    No image uploaded.
                </div>
            }
            <Card className="fixed bottom-0 max-w-5xl flex flex-col">
                <Carousel>
                    {allEditorTools.map(f => (
                        <div className={`bg-bg rounded-full p-4 cursor-pointer ${activeKey === f.key ? "bg-black" : ""}`} onClick={() => setActiveKey(f.key)}>
                            <f.icon className="w-8" color={`${activeKey === f.key ? "white" : "black"}`}/>
                        </div>
                    ))}
                </Carousel>
                <div key={activeKey} className="w-full my-4">
                    {renderControl()}
                </div>
            </Card>
        </div>
    )
} 

export default ImageEditor;