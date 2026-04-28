import ClickableBackground from "../layout/ClickableBackground";

type Props = {
    message: string;
    confirmMessage?: string;
    cancelMessage?: string;
    onConfirm: () => void;
    onCancel?: () => void;
}

const ConfirmDialog = ({ message, confirmMessage, cancelMessage, onConfirm, onCancel }: Props) => {
    return (
        <ClickableBackground bgColor="" onClick={onCancel ?? (() => {})}>
            <div className="bg-bg shadow-2xl px-8 py-6 flex flex-col items-center gap-6 animate-fade-in z-20">
                <h3 className="text-md">{message}</h3>
                <div className="flex flex-row justify-between gap-8 whitespace-nowrap">
                    <button className="border-black border-2 p-2 flex-1 cursor-pointer" onClick={(e) => { e.stopPropagation(); onConfirm()}}>{confirmMessage ?? "Yes"}</button>    
                    {onCancel && <button className="bg-black border-black text-white border-2 p-2 flex-1 cursor-pointer" onClick={(e) => { e.stopPropagation(); onCancel()}}>{cancelMessage ?? "No"}</button> }   
                </div>
            </div>    
        </ClickableBackground>
    );
};

export default ConfirmDialog;