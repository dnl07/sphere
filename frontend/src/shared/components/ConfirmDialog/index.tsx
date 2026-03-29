import ClickableBackground from "../layout/ClickableBackground";

type Props = {
    message: string;
    onConfirm: () => void;
    onCancel: () => void;
}

const ConfirmDialog = ({ message, onConfirm, onCancel }: Props) => {
    return (
        <ClickableBackground bgColor="" onClick={onCancel}>
            <div className="bg-bg shadow-2xl px-8 py-6 flex flex-col gap-6  animate-fade-in">
                <h3 className="text-md">{message}</h3>
                <div className="flex flex-row justify-between gap-8">
                    <button className="border-black border-2 p-2 flex-1" onClick={onConfirm}>Yes</button>    
                    <button className="bg-black border-black text-white border-2 p-2 flex-1" onClick={onCancel}>No</button>    
                </div>

            </div>    
        </ClickableBackground>
    );
};

export default ConfirmDialog;