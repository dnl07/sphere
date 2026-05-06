import { useRef, useState } from "react";

type Props = {
    min?: number;
    max?: number;
    initial?: number;
    label?: string;
    onChange?: (value: number) => void;
}

const Slider = ({ min = 0, max = 100, initial = 50, label, onChange }: Props) => {
    const [value, setValue] = useState<number>(initial);
    const trackRef = useRef<HTMLDivElement>(null);
    const isDragging = useRef<boolean>(false);

    const calcValue = (clientX: number) => {
        const track = trackRef.current;
        if (!track) return;

        const { left, width } = track.getBoundingClientRect();
        const ratio = Math.min(Math.max((clientX - left) / width, 0), 1)
        const newValue = Math.round(ratio * (max - min) + min);


        setValue(newValue);
        onChange?.(newValue);
    }

    const MouseDown = (e: React.MouseEvent<HTMLElement>) => {
        isDragging.current = true;
        calcValue(e.clientX);

        const onMouseMove = (e: MouseEvent) => {
            e.preventDefault();
            if (isDragging.current) {
                calcValue(e.clientX);
            }
        }

        const onMouseUp = () => {
            isDragging.current = false;

            window.removeEventListener("mousemove", onMouseMove);
            window.removeEventListener("mouseup", onMouseUp);
        }

        window.addEventListener("mousemove", onMouseMove);
        window.addEventListener("mouseup", onMouseUp);
    }

    const onTouchStart = (e: React.TouchEvent<HTMLElement>) => {
        isDragging.current = true;
        calcValue(e.touches[0].clientX);

        const onTouchMove = (e: TouchEvent) => {
            e.preventDefault();
            if (isDragging.current) {
                calcValue(e.touches[0].clientX);
            }
        }

        const onTouchEnd = () => {
            isDragging.current = false;

            window.removeEventListener("touchmove", onTouchMove);
            window.removeEventListener("touchend", onTouchEnd);
        }

        window.addEventListener("touchmove", onTouchMove, { passive: false});
        window.addEventListener("touchend", onTouchEnd);
    }

    const percentage = ((value - min) / (max - min)) * 100;

    return (
        <div>
            <div className="flex justify-between items-center py-3">
                {label &&
                    <h3>{label}</h3>
                }
                {value}
            </div>

            <div 
                className="w-full relative bg-border h-1.5 rounded-sm flex items-center"
                ref={trackRef}
            >
                <div 
                    className="absolute w-8 h-8 -translate-x-1/2 flex justify-center items-center"
                    style={{ left: `${percentage}%`}}
                    onMouseDown={MouseDown}
                    onTouchStart={onTouchStart}
                >
                    <div className="bg-black cursor-pointer w-4 h-4 rounded-full"/>
                </div>
            </div>

        </div>
    )
};

export default Slider;